using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Webshop2021Api.Data;
using Webshop2021Api.Logic.Products;
using Webshop2021Api.Logic.ViewModels;

namespace Webshop2021Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        public ProductsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet] 
        public IActionResult GetProducts()
        {
            return Ok(new ProductCrud(_context).GetProducts());
        }
        [HttpGet("User")]
        public IActionResult GetUserProducts()
        {
            return Ok(new ProductCrud(_context).GetUserProducts());
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            return Ok(new ProductCrud(_context).GetProduct(id));
        }
        [HttpPost]
        public IActionResult CreateProduct(AdminProductViewmodel product)
        {
            return Ok(new ProductCrud(_context).CreateProduct(product));
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveProduct(int id)
        {
            return Ok(new ProductCrud(_context).RemoveProduct(id));
        }
        [HttpPut]
        public IActionResult UpdateProduct(AdminProductViewmodel product)
        {
            return Ok(new ProductCrud(_context).UpdateProduct(product));
        }
    }
}
