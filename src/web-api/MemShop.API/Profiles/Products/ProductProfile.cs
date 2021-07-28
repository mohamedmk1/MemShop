using AutoMapper;
using MemShop.API.Models.Products;
using MemShop.Domain.Products;

namespace MemShop.API.Profiles.Products
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto, Product>()
                .ReverseMap();
        }
    }
}
