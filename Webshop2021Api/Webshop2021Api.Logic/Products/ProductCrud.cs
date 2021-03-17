using System;
using System.Collections.Generic;
using System.Text;
using Webshop2021Api.Data;
using Webshop2021Api.Domain.Models;

namespace Webshop2021Api.Logic.Products
{
    public class ProductCrud
    {
        private AppDbContext _context;

        public ProductCrud(AppDbContext context)
        {
            _context = context;
        }

        public void CreateProduct(Product product)
        {
            //example to remember (doesn't work yet)
            _context.Products.Add(product);
        }
    }
}
