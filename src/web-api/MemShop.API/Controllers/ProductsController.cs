using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MemShop.API.Controllers
{
    [ApiController]
    [Route("api/categories/{categoryId}/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public IMapper _mapper { get; }

        private readonly ICategoryInfoRepository _categoryInfoRepository;

        public ProductsController(ILogger<ProductsController> logger, 
            ICategoryInfoRepository categoryInfoRepository,
            IMapper mapper)
        {
            _logger = logger 
                ?? throw new ArgumentNullException(nameof(logger));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
            _categoryInfoRepository = categoryInfoRepository 
                ?? throw new ArgumentNullException(nameof(categoryInfoRepository));
        }

        [HttpGet]
        public IActionResult GetProducts(int categoryId)
        {
            try
            {
                if (!_categoryInfoRepository.IsCategoryExist(categoryId))
                {
                    _logger.LogInformation($"category id with {categoryId} was not found !");
                    return NotFound();
                }

                var products = _categoryInfoRepository.GetProducts(categoryId);

                return Ok(_mapper.Map<IEnumerable<ProductDto>>(products));
            }
            catch(Exception ex)
            {
                _logger.LogCritical($"Exception while getting product of category with id {categoryId}.", ex);
                return StatusCode(500, "A problem happened while handling your request.");
            }
        }

        [HttpGet("{productId}", Name = "GetProduct")]
        public IActionResult GetProduct(int categoryId, int productId)
        {
            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                _logger.LogInformation($"category id with {categoryId} was not found !");
                return NotFound();
            }

            var product = _categoryInfoRepository.GetProductForCategory(categoryId, productId);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProductDto>(product));
        }

        [HttpPost()]
        public IActionResult CreateProduct(int categoryId, [FromBody] ProductForCreationDto payload)
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

            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var finalProduct = _mapper.Map<Entities.Product>(payload);

            _categoryInfoRepository.AddProductForCategory(categoryId, finalProduct);
            _categoryInfoRepository.Save();

            var createdProductToReturn = _mapper
                .Map<Models.ProductDto>(finalProduct);

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


            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var productEntity = _categoryInfoRepository
                .GetProductForCategory(categoryId, productId);
            if(productEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(payload, productEntity);

            _categoryInfoRepository.UpdateProduct(categoryId, productEntity);

            _categoryInfoRepository.Save();

            return NoContent();
        }

        [HttpPatch("{productId}")]
        public IActionResult PartiallyUpdateProduct(int categoryId, int productId, 
            [FromBody] JsonPatchDocument<ProductForUpdateDto> patchDoc)
        {
            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var productEntity = _categoryInfoRepository
                .GetProductForCategory(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            var productToPatch = _mapper
                .Map<ProductForUpdateDto>(productEntity);

            patchDoc.ApplyTo(productToPatch, ModelState);

            if(!ModelState.IsValid)
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

            _categoryInfoRepository.UpdateProduct(categoryId, productEntity);

            _categoryInfoRepository.Save();


            return NoContent();
        }

        [HttpDelete("{productId}")]
        public IActionResult DeleteProduct(int categoryId, int productId)
        {
            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var productEntity = _categoryInfoRepository
                .GetProductForCategory(categoryId, productId);
            if (productEntity == null)
            {
                return NotFound();
            }

            _categoryInfoRepository.DeleteProduct(categoryId, productEntity);

            return NoContent();
        }
    }
}
