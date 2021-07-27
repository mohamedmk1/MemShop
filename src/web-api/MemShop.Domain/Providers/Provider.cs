using MemShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemShop.Domain.Providers
{
    public class Provider
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MaxLength(120)]
        public string Address { get; set; }
        [Required]
        [MaxLength(5)]
        public string ZipCode { get; set; }
        [Required]
        [MaxLength(50)]
        public string Country { get; set; }
        public ICollection<Product> Products{ get; set; }
    }
}
