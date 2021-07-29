using System.Collections.Generic;

namespace MemShop.API.Models.Products
{
    public class ProductCategoryDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public List<ProductDto> Products { get; set; }
           = new List<ProductDto>();
        public int NumberOfProducts
        {
            get
            {
                return Products.Count;
            }
        }
    }
}
