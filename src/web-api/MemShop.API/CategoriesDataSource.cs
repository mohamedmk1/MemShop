using MemShop.API.Models;
using System.Collections.Generic;

namespace MemShop.API
{
    public class CategoriesDataSource
    {
        public static CategoriesDataSource Current { get; } = new CategoriesDataSource();
        public List<CategoryDto> Categories { get; set; }

        public CategoriesDataSource()
        {
            Categories = new List<CategoryDto>()
            {
                new CategoryDto()
                {
                    Id = 1,
                    Label = "Category 1",
                    Description = "Category 1",
                    Products = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                            Id = 1,
                            Reference = "ref01",
                            Label = "Product 1",
                            Price = 13.45,
                            Image = "image01.png",
                            Description = "desc1"
                        },
                        new ProductDto()
                        {
                            Id = 2,
                            Reference = "ref02",
                            Label = "Product 2",
                            Price = 18.55,
                            Image = "image02.png",
                            Description = "desc2"
                        },
                        new ProductDto()
                        {
                            Id = 3,
                            Reference = "ref03",
                            Label = "Product 3",
                            Price = 20.255,
                            Image = "image03.png",
                            Description = "desc3"
                        }
                    }
                },
                new CategoryDto()
                {
                    Id = 2,
                    Label = "Category 2",
                    Description = "Category 2",
                    Products = new List<ProductDto>()
                    {
                        new ProductDto()
                        {
                            Id = 4,
                            Reference = "ref04",
                            Label = "Product 4",
                            Price = 16.25,
                            Image = "image04.png",
                            Description = "desc4"
                        },
                        new ProductDto()
                        {
                            Id = 5,
                            Reference = "ref05",
                            Label = "Product 5",
                            Price = 25.65,
                            Image = "image05.png",
                            Description = "desc5"
                        }
                    }
                }
            };
        }
    }
}
