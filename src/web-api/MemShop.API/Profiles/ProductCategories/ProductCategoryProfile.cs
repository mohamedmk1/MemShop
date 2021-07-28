using AutoMapper;
using MemShop.API.Models.ProductCategories;
using MemShop.Domain.ProductCategories;

namespace MemShop.API.Profiles.ProductCategories
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, CategoryWithoutProductsDto>();
            CreateMap<ProductCategory, CategoryDto>();
            CreateMap<CategoryForCreationDto, ProductCategory>();
            CreateMap<CategoryForUpdateDto, ProductCategory>()
                .ReverseMap();
        }
    }
}
