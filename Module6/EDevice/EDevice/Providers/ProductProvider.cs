using System.Collections.Generic;
using EDevice.Abstractions;
using Newtonsoft.Json;
using EDevice.Models;

namespace EDevice.Providers
{
    public class ProductProvider : IProductProvider
    {
        private const string DATA = "source.json";

        public ProductProvider(IFileService fileService)
        {
            var content = fileService.ReadFromFile(DATA);
            Products = JsonConvert.DeserializeObject<List<Product>>(content);
        }

        public List<Product> Products { get; set; }
    }
}
