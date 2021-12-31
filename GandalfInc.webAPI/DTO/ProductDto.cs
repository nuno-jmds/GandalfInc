using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandalfInc.webAPI.DTO
{
    public class ProductDto
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public string Reference { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }      

        public string Quantity { get; set; }
        public string Price { get; set; }

        public bool Active { get; set; }
    }
}
