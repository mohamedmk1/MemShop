﻿using AutoMapper;
using MemShop.API.Models;
using MemShop.Domain.Products;

namespace MemShop.API.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductForCreationDto, Product>();
            CreateMap<ProductForUpdateDto,Product>()
                .ReverseMap();
        }
    }
}
