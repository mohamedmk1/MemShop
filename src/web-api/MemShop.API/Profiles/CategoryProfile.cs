using AutoMapper;
using MemShop.API.Models;
using MemShop.Domain.ProductCategories;

namespace MemShop.API.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<ProductCategory, CategoryWithoutProductsDto>();
            CreateMap<ProductCategory, CategoryDto>();
            CreateMap<CategoryForCreationDto, ProductCategory>();
            CreateMap<CategoryForUpdateDto, ProductCategory>()
                .ReverseMap();
        }
    }
}
