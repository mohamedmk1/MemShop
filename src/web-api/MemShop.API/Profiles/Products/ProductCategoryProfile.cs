using AutoMapper;
using MemShop.API.Models.Products;
using MemShop.Domain.Products;

namespace MemShop.API.Profiles.Products
{
    public class ProductCategoryProfile : Profile
    {
        public ProductCategoryProfile()
        {
            CreateMap<ProductCategory, ProductCategoryWithoutProductsDto>();
            CreateMap<ProductCategory, ProductCategoryDto>();
            CreateMap<ProductCategoryForCreationDto, ProductCategory>();
            CreateMap<ProductCategoryForUpdateDto, ProductCategory>()
                .ReverseMap();
        }
    }
}
