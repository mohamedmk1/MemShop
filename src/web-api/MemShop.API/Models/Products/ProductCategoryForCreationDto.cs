using System.ComponentModel.DataAnnotations;

namespace MemShop.API.Models.Products
{
    public class ProductCategoryForCreationDto
    {
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }
    }
}
