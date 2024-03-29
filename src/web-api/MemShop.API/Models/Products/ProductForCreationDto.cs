﻿using System.ComponentModel.DataAnnotations;

namespace MemShop.API.Models.Products
{
    public class ProductForCreationDto
    {
        [Required]
        [MaxLength(10)]
        public string Reference { get; set; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [Required]
        public double Price { get; set; }
        [MaxLength(255)]
        public string Image { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
