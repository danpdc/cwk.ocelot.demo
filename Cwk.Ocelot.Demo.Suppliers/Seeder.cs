using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Suppliers
{
    public class Seeder
    {
        public Seeder()
        {
            Suppliers = new List<Supplier>
            {
                new Supplier {Id=0, Name="Amazon", Country="USA"},
                new Supplier {Id=1, Name="AliExpress", Country="China"}
            };
        }

        public List<Supplier> Suppliers { get; set; }
    }
}
