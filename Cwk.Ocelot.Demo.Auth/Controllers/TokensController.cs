using Cwk.Ocelot.Demo.Auth.Interfaces;
using Cwk.Ocelot.Demo.Auth.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Auth.Controllers
{
    [Route("api/[controller]")]
    public class TokensController : Controller
    {
        private ITokenGenerator _tokenGen;
        public TokensController(ITokenGenerator tokenGen)
        {
            _tokenGen = tokenGen;
        }

        [HttpPost]
        public IActionResult GenerateToken([FromBody] UserInfo userInfo)
        {
            var accessToken = new AccessToken();
            accessToken.Token = _tokenGen.GenerateToken(userInfo);
            return Ok(accessToken);
        }
    }
}
