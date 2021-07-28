using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MemShop.API.Models.CustomerTypes
{
    public class CustomerTypeDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public string Description { get; set; }
    }
}
