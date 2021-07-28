using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Models.Products;
using MemShop.Domain.Products;
using MemShop.Services.Products;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MemShop.API.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public IMapper _mapper { get; }

        private readonly IProductService _productservice;

        public ProductsController(ILogger<ProductsController> logger,
            IProductService productservice,
            IMapper mapper)
        {
            _logger = logger
                ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _productservice = productservice
                ?? throw new ArgumentNullException(nameof(productservice));
        }

        [HttpGet]
        public IActionResult GetProducts(int categoryId)
        {
            try
            {
                var products = _productservice.GetAllByCategoryId(categoryId);

                if (products is null)
                {
                    _logger.LogInformation($"category id with {categoryId} was not found !");
                    return NotFound();
                }
                return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
            }
            catch (Exception ex)
            {
                _logger.LogCritical($"Exception while getting product of category with id {categoryId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public IActionResult GetProduct(int categoryId, int productId)
        {
            var product = _productservice.GetProductForCategory(categoryId, productId);

            if (product is null)
            {
                _logger.LogInformation($"category id with {categoryId} was not found !");
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost()]
        public IActionResult CreateProduct(int categoryId, [FromBody] ProductForCreationDto payload)
        {
            //could be added in a validator or service ?
            if (payload.Label == payload.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "Label product must be different from description.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var finalProduct = _mapper.Map<Product>(payload);

            finalProduct = _productservice.CreateProductForCategory(categoryId, finalProduct);

            if (finalProduct is null)
            {
                return NotFound();
            }

            var createdProductToReturn = _mapper
                .Map<ProductDto>(finalProduct);

            return CreatedAtRoute(
                "GetProduct",
                new { categoryId, productId = createdProductToReturn.Id },
                createdProductToReturn);
        }

        [HttpPut("{productId}")]
        public IActionResult UpdateProduct(int categoryId, int productId, [FromBody] ProductForUpdateDto payload)
        {
            if (payload.Label == payload.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "Label product must be different from description.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var productEntity = _productservice
                .GetProductForCategory(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(payload, productEntity);

            _productservice.UpdateProduct(productEntity);

            return NoContent();
        }

        [HttpPatch("{productId}")]
        public IActionResult PartiallyUpdateProduct(int categoryId, int productId,
            [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
        {
            var productEntity = _productservice
                .GetProductForCategory(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            var productToPatch = _mapper
                .Map<ProductForUpdateDto>(productEntity);

            patchDoc.ApplyTo(productToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (productToPatch.Label == productToPatch.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "Label product must be different from description.");
            }

            if (!TryValidateModel(productToPatch))
            {
                return BadRequest();
            }

            _mapper.Map(productToPatch, productEntity);

            _productservice.UpdateProduct(productEntity);

            return NoContent();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int categoryId, int productId)
        {
            var productEntity = _productservice
                .GetProductForCategory(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            _productservice.DeleteProduct(productEntity);

            return NoContent();
        }
    }
}
