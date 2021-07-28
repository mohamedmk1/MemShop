using AutoMapper;
using MemShop.API.Models.CustomerTypes;
using MemShop.Domain.CustomerTypes;
using MemShop.Services.CustomerTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace MemShop.API.Controllers.CustomerTypes
{
    [ApiController]
    [Route("api/customerTypes")]
    public class CustomerTypesController : ControllerBase
    {
        private readonly ICustomerTypeService _customerTypeService;
        private readonly IMapper _mapper;

        public CustomerTypesController(ICustomerTypeService customerTypeService, IMapper mapper)
        {
            _customerTypeService = customerTypeService
                ?? throw new ArgumentNullException(nameof(customerTypeService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetCustomerTypes()
        {
            var customerTypesEntities = _customerTypeService.GetCustomerTypes();

            return Ok(_mapper.Map<IEnumerable<CustomerTypeDto>>(customerTypesEntities));
        }

        [HttpGet("{id}", Name = "GetCustomerTypeById")]
        public IActionResult GetCustomerTypeById(int id)
        {
            var customerType = _customerTypeService.GetCustomerTypeById(id);

            if (customerType == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CustomerTypeDto>(customerType));
        }

        [HttpPost()]
        public IActionResult CreateCustomerType([FromBody] CustomerTypeForCreationDto payload)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (payload.Label == payload.Description)
            {
                ModelState.AddModelError("Description", "Label must be different from description.");
            }

            var finalCustomerType = _mapper.Map<CustomerType>(payload);
            var createdCustomerType = _customerTypeService.CreateCustomerType(finalCustomerType);

            return CreatedAtRoute(
                "GetCustomerTypeById",
                new { id = createdCustomerType.Id },
                _mapper.Map<CustomerTypeDto>(createdCustomerType));
        }

        [HttpPut("{customerTypeId}")]
        public IActionResult UpdateCustomerType(int customerTypeId, [FromBody] CustomerTypeForUpdateDto payload)
        {
            if (payload.Label == payload.Description)
            {
                ModelState.AddModelError("Description", "Label must be different from description.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_customerTypeService.IsCustomerTypeExist(customerTypeId))
            {
                return NotFound();
            }

            CustomerType newCustomerType = new CustomerType(customerTypeId, payload.Label, payload.Description);

            _customerTypeService.UpdateCustomerType(newCustomerType);

            return CreatedAtRoute(
                "GetCustomerTypeById",
                new { id = customerTypeId },
                _mapper.Map<CustomerTypeDto>(newCustomerType));
        }

        [HttpDelete("{customerTypeId}")]
        public IActionResult DeleteCustomerType(int customerTypeId)
        {
            if (!_customerTypeService.IsCustomerTypeExist(customerTypeId))
            {
                return NotFound();
            }

            var customerType = _customerTypeService.GetCustomerTypeById(customerTypeId);

            _customerTypeService.DeleteCustomerType(customerType);

            return NoContent();
        }
    }
}
