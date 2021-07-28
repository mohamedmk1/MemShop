using System.ComponentModel.DataAnnotations;

namespace MemShop.API.Models.Providers
{
    public class ProviderDtoForCreation
    {
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
    }
}
