using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDevice.Models;

namespace EDevice.Abstractions
{
    public interface IProductService
    {
        Task<IReadOnlyCollection<Product>> Get(List<Product> products);
        Task<Product> Delete(int id);
        Task<int> Post(Product product);
        Task<bool> Put(int id, Product newProduct);
    }
}
