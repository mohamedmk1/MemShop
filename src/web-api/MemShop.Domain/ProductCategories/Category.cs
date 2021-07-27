using MemShop.Domain.Products;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.Domain.ProductCategories
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public ICollection<Product> Products { get; set; }
            = new List<Product>();
    }
}
