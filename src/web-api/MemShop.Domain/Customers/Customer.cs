using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MemShop.Domain.Customers
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string Adresse { get; set; }
        [MaxLength(10)]
        public string ZipCode { get; set; }
        [ForeignKey("CustomerTypeId")]
        public CustomerType CustomerType { get; set; }
        public int CustomerTypeId { get; set; }
    }
}
