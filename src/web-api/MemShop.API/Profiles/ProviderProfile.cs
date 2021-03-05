using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Profiles
{
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<Entities.Provider, Models.ProviderDto>();
            CreateMap<Entities.Provider, Models.ProviderDtoForCreation>()
                .ReverseMap();
        }
        
    }
}
