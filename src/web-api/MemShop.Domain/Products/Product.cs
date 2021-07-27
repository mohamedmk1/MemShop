using MemShop.Domain.ProductCategories;
using MemShop.Domain.Providers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.Domain.Products
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(10)]
        public string Reference { get; set; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [Required]
        public double Price { get; set; }
        public string Image { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [ForeignKey("CategoryId")]
        public ProductCategory Category { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("ProviderId")]
        public Provider Provider { get; set; }
        public int ProviderId { get; set; }
    }
}
