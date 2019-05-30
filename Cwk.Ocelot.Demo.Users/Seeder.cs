using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Users
{
    public class Seeder
    {
        public Seeder()
        {
            Users = new List<User>
            {
                new User {Id = 0, Name="Dan Patrascu", Country="Romania" },
                new User {Id = 1, Name="John Snow", Country="Westeros"}
            };
        }

        public List<User> Users { get; set; }
    }
}
