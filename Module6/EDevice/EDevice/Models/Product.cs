using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDevice.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
    }
}
