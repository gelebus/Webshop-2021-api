using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2021Api.Data;
using Webshop2021Api.Domain.Models;
using Webshop2021Api.Logic.ViewModels;

namespace Webshop2021Api.Logic.Stocks
{
    public class StockCrud
    {
        private AppDbContext _context;

        public StockCrud(AppDbContext context)
        {
            _context = context;
        }

        public async Task<StockViewModel> CreateStock(StockViewModel stockvm)
        {
            Stock stock = new Stock()
            {
                ProductId = stockvm.ProductId,
                Description = stockvm.Description,
                Quantity = stockvm.Quantity
            };
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();
            return new StockViewModel() 
            { 
                Id = stock.Id,
                Description = stock.Description,
                ProductId = stock.ProductId,
                Quantity = stock.Quantity
            };
        }
        public async Task<IEnumerable<StockViewModel>> UpdateStocks(IEnumerable<StockViewModel> stockvms)
        {
            List<Stock> stocks = new List<Stock>();
            foreach(var stockvm in stockvms)
            {
                stocks.Add(new Stock()
                {
                    Id = stockvm.Id,
                    Description = stockvm.Description,
                    ProductId = stockvm.ProductId,
                    Quantity = stockvm.Quantity
                });
            }
            _context.Stocks.UpdateRange(stocks);

            await _context.SaveChangesAsync();

            return stockvms;
        }

        public async Task<bool> RemoveStock(int id)
        {
            var stock = _context.Stocks.FirstOrDefault(a => a.Id == id);

            _context.Remove(stock);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<StockViewModel> GetStocks(int productId)
        {
            var stock = _context.Stocks
                .Where(a => a.ProductId == productId)
                .Select(a => new StockViewModel()
                {
                    Id = a.Id,
                    ProductId = a.ProductId,
                    Description = a.Description,
                    Quantity = a.Quantity
                })
                .ToList();
            return stock;
        }
    }
}
