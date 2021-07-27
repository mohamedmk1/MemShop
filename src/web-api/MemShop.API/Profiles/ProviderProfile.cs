using AutoMapper;
using MemShop.API.Models;
using MemShop.API.Models.Provider;
using MemShop.Domain.Providers;

namespace MemShop.API.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Provider, ProviderDto>();
            CreateMap<Provider, ProviderDtoForCreation>()
                .ReverseMap();
        }

    }
}
