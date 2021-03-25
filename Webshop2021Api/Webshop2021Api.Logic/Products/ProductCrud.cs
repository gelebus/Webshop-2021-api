using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webshop2021Api.Data;
using Webshop2021Api.Domain.Models;
using Webshop2021Api.Logic.ViewModels;

namespace Webshop2021Api.Logic.Products
{
    public class ProductCrud
    {
        private AppDbContext _context;

        public ProductCrud(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateProduct(AdminProductViewmodel product)
        {
            _context.Products.Add(new Product() 
            { 
                Name= product.Name,
                Description = product.Description,
                Value = product.Value
            });
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            
        }
        public async Task UpdateProduct(AdminProductViewmodel productvm)
        {
            var product = _context.Products.FirstOrDefault(a => a.Id == productvm.Id);
            product.Name = productvm.Name;
            product.Description = productvm.Description;
            product.Value = productvm.Value;

            await _context.SaveChangesAsync();
        }
        public async Task RemoveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(a => a.Id == id);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
        public AdminProductViewmodel GetProduct(int id)
        {
            var product = _context.Products.Where(a => a.Id == id).Select(a => new AdminProductViewmodel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Value = a.Value
            }).FirstOrDefault();
            return product;
        }
        public IEnumerable<AdminProductViewmodel> GetProducts()
        {
            return _context.Products.ToList().Select(a => new AdminProductViewmodel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Value = a.Value
            });
        }
        public IEnumerable<ProductViewmodel> GetUserProducts()
        {
            return _context.Products.ToList().Select(a => new ProductViewmodel()
            {
                Name = a.Name,
                Description = a.Description,
                Value = $"€ {a.Value.ToString("N2")}"
            });
        }
    }
}
