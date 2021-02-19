using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MemShop.API.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryInfoRepository _categoryInfoRepository;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryInfoRepository categoryInfoRepository,
            IMapper mapper)
        {
            _categoryInfoRepository = categoryInfoRepository 
                ?? throw new ArgumentNullException(nameof(categoryInfoRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoryEntities = _categoryInfoRepository.GetCategories();

            return Ok(_mapper.Map<IEnumerable<CategoryWithoutProductsDto>>(categoryEntities));
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetCategory(int id, bool includeProducts = false)
        {
            var category = _categoryInfoRepository.GetCategory(id, includeProducts);

            if (category == null)
            {
                return NotFound();
            }

            if (includeProducts)
            {
                return Ok(_mapper.Map<CategoryDto>(category));
            }

            return Ok(_mapper.Map<CategoryWithoutProductsDto>(category));
        }

        [HttpPost()]
        public IActionResult CreateCategory([FromBody] CategoryForCreationDto payload)
        {
            if(payload.Label == payload.Description)
            {
                ModelState.AddModelError("Description", "Label category must be different from description.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var finalCategory = _mapper
                .Map<Entities.Category>(payload);

            _categoryInfoRepository.AddCategory(finalCategory);
            _categoryInfoRepository.Save();

            var createdCategoryToReturn = _mapper
                .Map<Models.CategoryDto>(finalCategory);

            return CreatedAtRoute(
                "GetCategory",
                new { id = finalCategory.Id },
                createdCategoryToReturn);

        }

        [HttpPut("{categoryId}")]
        public IActionResult UpdateCategory(int categoryId, [FromBody] CategoryForUpdateDto payload) 
        {

            if (payload.Label == payload.Description)
            {
                ModelState.AddModelError("Description", "Label category must be different from description.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var categoryEntity = _categoryInfoRepository.GetCategory(categoryId, false);
            
            if(categoryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(payload, categoryEntity);

            _categoryInfoRepository.UpdateCategory(categoryEntity);

            _categoryInfoRepository.Save();

            return NoContent();
        }

        [HttpPatch("{categoryId}")]
        public IActionResult PartiallyUpdatedCategory(int categoryId, 
            [FromBody] JsonPatchDocument<CategoryForUpdateDto> patchDoc)
        {
            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var categoryEntity = _categoryInfoRepository
                .GetCategory(categoryId, false);

            var categoryToPatch = _mapper
                .Map<CategoryForUpdateDto>(categoryEntity);

            patchDoc.ApplyTo(categoryToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (categoryToPatch.Label == categoryToPatch.Description)
            {
                ModelState.AddModelError(
                    "Description",
                    "Label category must be different from description.");
            }

            if (!TryValidateModel(categoryToPatch))
            {
                return BadRequest();
            }

            _mapper.Map(categoryToPatch, categoryEntity);

            _categoryInfoRepository.UpdateCategory(categoryEntity);

            _categoryInfoRepository.Save();

            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            if (!_categoryInfoRepository.IsCategoryExist(categoryId))
            {
                return NotFound();
            }

            var categoryEntity = _categoryInfoRepository.GetCategory(categoryId, false);
            if(categoryEntity == null)
            {
                return NotFound();
            }

            _categoryInfoRepository.DeleteCategory(categoryEntity);
            _categoryInfoRepository.Save();

            return NoContent();
        }
    }
}
