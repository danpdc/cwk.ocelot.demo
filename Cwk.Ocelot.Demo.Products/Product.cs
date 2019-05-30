using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Products
{
    public class Product
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
