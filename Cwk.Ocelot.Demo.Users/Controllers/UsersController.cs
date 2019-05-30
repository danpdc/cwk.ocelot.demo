using Cwk.Ocelot.Demo.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Users.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private Seeder _seeder;
        private readonly IHttpContextAccessor _ctxAccessor;
        public UsersController(Seeder seeder, IHttpContextAccessor ctxAccessor)
        {
            _seeder = seeder;
            _ctxAccessor = ctxAccessor;
        }

        public IActionResult GetUsers()
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            return Ok(_seeder.Users);
        }

        [Route("{id}", Name ="GetUserById")]
        public IActionResult GetUserById(int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            return Ok(_seeder.Users.FirstOrDefault(u => u.Id == id));
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            _seeder.Users.Add(user);
            return CreatedAtRoute("GetUserById", new { id = user.Id}, user);
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateUser([FromBody] User user, int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            var toUpdate = _seeder.Users.FirstOrDefault(u => u.Id == id);
            toUpdate.Name = user.Name;
            toUpdate.Country = user.Country;
            return Ok("User updated");
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteUser(int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            var toDelete = _seeder.Users.FirstOrDefault(u => u.Id == id);
            _seeder.Users.Remove(toDelete);
            return Ok("User deleted");
        }
    }
}
