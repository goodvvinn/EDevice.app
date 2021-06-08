using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EDevice.Controllers;
using EDevice.Providers;
using EDevice.Models;
using Microsoft.Extensions.Logging;
using EDevice.Abstractions;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace EDevice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageController : ControllerBase
    {
        private readonly ILogger<ManageController> _logger;

        private readonly IProductService _productService;

        public ManageController(ILogger<ManageController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public async Task<IActionResult> Get(List<Product> products)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} code 200 (success)");
            var data = await _productService.Get(products);
            return data is null ? NotFound() : new JsonResult(data);
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBy(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            var data = await _productService.Find(id);
            return data is null ? NotFound() : new JsonResult(data);
        }

        // POST api/<ValuesController>
        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Product product)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} code 200 (success)");
            var newProductId = await _productService.Create(product);
            return CreatedAtAction(nameof(Create), new { id = newProductId });
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Product product)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} code 200 (success)");
            var result = await _productService.Update(id, product);
            return result ? NotFound() : CreatedAtAction(nameof(Put), new { id = product.Id });
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _logger.LogInformation($"{DateTime.UtcNow}: {Request.Path.Value} {Request.Method} request received");
            var result = await _productService.Find(id);
            return result ? NotFound() : CreatedAtAction(nameof(Delete), new { id = product.Id });
        }
    }
}
