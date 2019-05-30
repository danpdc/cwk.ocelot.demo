using Cwk.Ocelot.Demo.Auth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Auth.Interfaces
{
    public interface ITokenGenerator
    {
        string GenerateToken(UserInfo userInfo);
    }
}
