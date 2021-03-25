using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Webshop2021Api.Data;
using Webshop2021Api.Logic.Products;
using Webshop2021Api.Logic.ViewModels;

namespace Webshop2021Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private ProductCrud productCrud;
        public ProductsController(AppDbContext context)
        {
            productCrud = new ProductCrud(context);
        }
        [HttpGet] 
        public IActionResult GetProducts()
        {
            return Ok(productCrud.GetProducts());
        }
        [HttpGet("User")]
        public IActionResult GetUserProducts()
        {
            return Ok(productCrud.GetUserProducts());
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(productCrud.GetProduct(id));
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(JObject jObject)
        {
            var product = jObject.ToObject<AdminProductViewmodel>();
            await productCrud.CreateProduct(product);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            return Ok(productCrud.RemoveProduct(id));
        }
        [HttpPut]
        public IActionResult UpdateProduct(AdminProductViewmodel product)
        {
            return Ok(productCrud.UpdateProduct(product));
        }
    }
}
