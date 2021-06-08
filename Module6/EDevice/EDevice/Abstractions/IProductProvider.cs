using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDevice.Models;

namespace EDevice.Abstractions
{
    public interface IProductProvider
    {
         List<Product> Products { get; set; }
    }
}
