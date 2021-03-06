using System;
using System.Collections.Generic;
using System.Text;

namespace Webshop2021Api.Domain.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
        public IEnumerable<Stock> Stock { get; set; }
    }
}
