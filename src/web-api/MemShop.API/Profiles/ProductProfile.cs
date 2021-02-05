using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Profiles
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<Entities.Product, Models.ProductDto>();
            CreateMap<Models.ProductForCreationDto, Entities.Product>();
            CreateMap<Models.ProductForUpdateDto, Entities.Product>()
                .ReverseMap();
        }
    }
}
