using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Models
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
        public List<ProductDto> Products { get; set; }
           = new List<ProductDto>();
        public int NumberOfProducts { 
            get {
                return Products.Count;
            } 
        }
    }
}
