using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Entities.Category, Models.CategoryWithoutProductsDto>();
            CreateMap<Entities.Category, Models.CategoryDto>();
        }
    }
}
