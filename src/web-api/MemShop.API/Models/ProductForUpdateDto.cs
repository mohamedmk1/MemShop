﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Models
{
    public class ProductForUpdateDto
    {
        [Required]
        [MaxLength(10)]
        public string Reference { get; set; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        public double Price { get; set; }
        [MaxLength(255)]
        public string Image { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
