using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EDevice.Abstractions;
using EDevice.Models;

namespace EDevice.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductProvider _productProvider;

        public ProductService(IProductProvider provider)
        {
            _productProvider = provider;
        }

        public async Task<IReadOnlyCollection<Product>> Get(List<Product> products)
        {
            return await Task.FromResult(_productProvider.Products.ToList());
        }

        public async Task<Product> Delete(int id)
        {
            return await Task.FromResult(_productProvider.Products.FirstOrDefault(item => item.Id == id));
        }

        public async Task<int> Post(Product products)
        {
            products.Id = products.GetHashCode();
            _productProvider.Products.Add(products);
            return await Task.FromResult(products.Id);
        }

        public async Task<bool> Put(int id, Product newProduct)
        {
            var productIndex = await Task.FromResult(_productProvider.Products.FindIndex(item => item.Id == id));
            if (productIndex < 0)
            {
                return false;
            }
            else
            {
                _productProvider.Products[productIndex] = newProduct;
            }

            return true;
        }
    }
}
