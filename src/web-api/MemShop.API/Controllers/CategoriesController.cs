﻿using AutoMapper;
using MemShop.API.Models;
using MemShop.Data.Entities;
using MemShop.Services;
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
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService,
            IMapper mapper)
        {
            _categoryService = categoryService
                ?? throw new ArgumentNullException(nameof(categoryService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var categoryEntities = _categoryService.GetCategories();

            return Ok(_mapper.Map<IEnumerable<CategoryWithoutProductsDto>>(categoryEntities));
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public IActionResult GetCategory(int id, bool includeProducts = false)
        {
            var category = (includeProducts) ? _categoryService.GetCategoryByIdWithProducts(id)
                : _categoryService.GetCategoryById(id);

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
            // In validator or service ?
            if (payload.Label == payload.Description)
            {
                ModelState.AddModelError("Description", "Label category must be different from description.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var finalCategory = _mapper
                .Map<Category>(payload);

            _categoryService.CreateCategory(finalCategory);

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

            var categoryEntity = _categoryService.GetCategoryById(categoryId);

            if (categoryEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(payload, categoryEntity);

            _categoryService.UpdateCategory(categoryEntity);

            var updatedCategoryToReturn = _mapper
                .Map<Models.CategoryDto>(categoryEntity);

            return CreatedAtRoute(
                "GetCategory",
                new { id = categoryId },
                updatedCategoryToReturn);
        }

        [HttpPatch("{categoryId}")]
        public IActionResult PartiallyUpdatedCategory(int categoryId,
            [FromBody] JsonPatchDocument<CategoryForUpdateDto> patchDoc)
        {
            var categoryEntity = _categoryService
                .GetCategoryById(categoryId);
            
            if (categoryEntity == null)
            {
                return NotFound();
            }
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

            _categoryService.UpdateCategory(categoryEntity);

            return NoContent();
        }

        [HttpDelete("{categoryId}")]
        public IActionResult DeleteCategory(int categoryId)
        {
            var categoryEntity = _categoryService.GetCategoryById(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }

            _categoryService.DeleteCategory(categoryEntity);

            return NoContent();
        }
    }
}
