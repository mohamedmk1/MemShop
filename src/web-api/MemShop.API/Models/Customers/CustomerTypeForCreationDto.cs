﻿using System.ComponentModel.DataAnnotations;

namespace MemShop.API.Models.Customers
{
    public class CustomerTypeForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
