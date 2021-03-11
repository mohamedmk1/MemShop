using AutoMapper;
using MemShop.API.Models;
using MemShop.Data.Entities;

namespace MemShop.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryWithoutProductsDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryForCreationDto, Category>();
            CreateMap<CategoryForUpdateDto, Category>()
                .ReverseMap();
        }
    }
}
