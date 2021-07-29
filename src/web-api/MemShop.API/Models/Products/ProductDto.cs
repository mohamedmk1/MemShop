﻿namespace MemShop.API.Models.Products
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Reference { get; set; }
        public string Label { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
    }
}
