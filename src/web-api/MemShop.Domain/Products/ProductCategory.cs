using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemShop.Domain.Products
{
    [Table("ProductCategories")]
    public class ProductCategory
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
