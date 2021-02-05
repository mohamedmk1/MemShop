using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Services;
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

        [HttpGet("{id}")]
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
    }
}
