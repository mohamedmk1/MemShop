using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Controllers
{
    [ApiController]
    [Route("api/providers")]
    public class ProvidersController : ControllerBase
    {
        private readonly IProviderRepository _providerRepository;
        private readonly IMapper _mapper;

        public ProvidersController(IProviderRepository providerRepository,
            IMapper mapper)
        {
            _providerRepository = providerRepository
               ?? throw new ArgumentNullException(nameof(providerRepository));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            var providerEntities = _providerRepository.GetProviders();

            return Ok(_mapper.Map<IEnumerable<ProviderDto>>(providerEntities));
        }

        [HttpGet("{id}", Name = "GetProvider")]
        public IActionResult GetProvider(int id)
        {
            var provider = _providerRepository.GetProvider(id);

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
                .Map<Entities.Provider>(payload);

            _providerRepository.AddProvider(finalProvider);
            _providerRepository.Save();

            var createdProviderToReturn = _mapper
                .Map<Models.ProviderDto>(finalProvider);

            return CreatedAtRoute(
                "GetProvider",
                new { id = finalProvider.Id },
                createdProviderToReturn);

        }

        [HttpPut("{providerId}")]
        public IActionResult UpdateProvicer(int providerId, [FromBody] ProviderDtoForCreation payload)
        {


            var providerEntity = _providerRepository.GetProvider(providerId);

            if (providerEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(payload, providerEntity);

            _providerRepository.UpdateProvider(providerEntity);

            _providerRepository.Save();

            var updatedProviderToReturn = _mapper
                .Map<Models.ProviderDto>(providerEntity);

            return CreatedAtRoute(
                "GetProvider",
                new { id = providerId },
                updatedProviderToReturn);
        }

        [HttpDelete("{providerId}")]
        public IActionResult DeleteProvider(int providerId)
        {
            var providerEntity = _providerRepository.GetProvider(providerId);

            if (providerEntity == null)
            {
                return NotFound();
            }

            _providerRepository.DeleteProvider(providerEntity);
            _providerRepository.Save();

            return NoContent();
        }
    }
}
