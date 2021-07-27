using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Models.Provider;
using MemShop.Domain.Providers;
using MemShop.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderService providerService,
            IMapper mapper)
        {
            _providerService = providerService
               ?? throw new ArgumentNullException(nameof(providerService));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            var providerEntities = _providerService.GetAllWithProducts();

            return Ok(_mapper.Map<IEnumerable<ProviderDto>>(providerEntities));
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public IActionResult GetProvider(int id)
        {
            var provider = _providerService.GetProviderById(id);

            if (provider == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<ProviderDto>(provider));
        }

        [HttpPost()]
        public IActionResult CreateProvider([FromBody] ProviderDtoForCreation payload)
        {
            var finalProvider = _mapper
                .Map<Provider>(payload);

            _providerService.CreateProvider(finalProvider);

            var createdProviderToReturn = _mapper
                .Map<ProviderDto>(finalProvider);

            return CreatedAtRoute(
                "GetProvider",
                new { id = finalProvider.Id },
                createdProviderToReturn);

        }

        [HttpPut("{providerId}")]
        public IActionResult UpdateProvicer(int providerId, [FromBody] ProviderDtoForCreation payload)
        {


            var providerEntity = _providerService.GetProviderById(providerId);

            if (providerEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(payload, providerEntity);

            _providerService.UpdateProvider(providerEntity);

            var updatedProviderToReturn = _mapper
                .Map<ProviderDto>(providerEntity);

            return CreatedAtRoute(
                "GetProvider",
                new { id = providerId },
                updatedProviderToReturn);
        }

        [HttpDelete("{providerId}")]
        public IActionResult DeleteProvider(int providerId)
        {
            var providerEntity = _providerService.GetProviderById(providerId);

            if (providerEntity == null)
            {
                return NotFound();
            }

            _providerService.DeleteProvider(providerEntity);

            return NoContent();
        }
    }
}
