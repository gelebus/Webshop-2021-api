using System;
using System.Collections.Generic;
using System.Text;
using Webshop2021Api.Data;

namespace Webshop2021Api.Logic.Stock
{
    public class StockCrud
    {
        private AppDbContext _context;

        public StockCrud(AppDbContext context)
        {
            _context = context;
        }
    }
}
