using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Webshop2021Api.Data;
using Webshop2021Api.Logic.Products;
using Webshop2021Api.Logic.Stocks;
using Webshop2021Api.Logic.ViewModels;

namespace Webshop2021Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StocksController : Controller
    {
        private StockCrud stockCrud;
        public StocksController(AppDbContext context)
        {
            stockCrud = new StockCrud(context);
        }
        [HttpGet] 
        public IActionResult GetStocks(int productId)
        {
            return Ok(stockCrud.GetStocks(productId));
        }
        [HttpPost]
        public async Task<IActionResult> CreateStock(StockViewModel stock)
        {
            return Ok(await stockCrud.CreateStock(stock));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStock(int id)
        {
            return Ok(await stockCrud.RemoveStock(id));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateStocks(IEnumerable<StockViewModel>stocks)
        {
            return Ok(await stockCrud.UpdateStocks(stocks));
        }
    }
}
