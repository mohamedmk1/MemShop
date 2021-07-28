using AutoMapper;
using MemShop.API.Models.Providers;
using MemShop.Domain.Providers;

namespace MemShop.API.Profiles.Providers
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
