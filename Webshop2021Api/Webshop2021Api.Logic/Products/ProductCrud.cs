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

        public async Task<AdminProductViewmodel> CreateProduct(AdminProductViewmodel product)
        {
            var p = new Product()
            {
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
            _context.Products.Add(p);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return new AdminProductViewmodel()
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Value = p.Value
            };
        }
        public async Task<AdminProductViewmodel> UpdateProduct(AdminProductViewmodel productvm)
        {
            var product = _context.Products.FirstOrDefault(a => a.Id == productvm.Id);
            product.Name = productvm.Name;
            product.Description = productvm.Description;
            product.Value = productvm.Value;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            return new AdminProductViewmodel()
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
        }
        public async Task<bool> RemoveProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(a => a.Id == id);
            _context.Products.Remove(product);
            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception er)
            {
                return false;
            }
            
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
            var p = _context.Products.ToList().Select(a => new AdminProductViewmodel()
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Value = a.Value
            });
            return p;
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
