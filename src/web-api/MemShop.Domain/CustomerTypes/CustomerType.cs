using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MemShop.Domain.CustomerTypes
{
    public class CustomerType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string Label { get; set; }
        [MaxLength(255)]
        public string Description { get; set; }

        public CustomerType()
        {
                
        }

        public CustomerType(int id, string label, string description)
        {
            this.Id = id;
            this.Label = label;
            this.Description = description;
        }
    }
}
