using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Products
{
    public class Seeder
    {
        public Seeder()
        {
            Products = new List<Product>
            {
                new Product {Id=0, Code="CWK001", Name="ASUS VS197DE", Description="17 inch display", Price=75.90m},
                new Product {Id=1, Code="CWK002", Name="Logitech K120", Description="keyboard", Price=11.24m},
                new Product {Id=2, Code="CWK003", Name="Lenovo V330 laptop", Description="Business laptop", Price=704.78m}
            };
        }

        public List<Product> Products { get; set; }
    }
}
