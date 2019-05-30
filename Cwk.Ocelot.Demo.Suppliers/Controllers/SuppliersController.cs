using Cwk.Ocelot.Demo.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Suppliers.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : Controller
    {
        private Seeder _seeder;
        private readonly IHttpContextAccessor _ctxAccessor;
        public SuppliersController(Seeder seeder, IHttpContextAccessor ctxAccessor)
        {
            _seeder = seeder;
            _ctxAccessor = ctxAccessor;
        }

        public IActionResult GetSuppliers()
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            return Ok(_seeder.Suppliers);
        }

        [Route("{id}", Name = "GetSupplierById")]
        public IActionResult GetSupplierById(int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            return Ok(_seeder.Suppliers.FirstOrDefault(s => s.Id == id));
        }

        [HttpPost]
        public IActionResult CreateSupplier([FromBody] Supplier supplier)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            _seeder.Suppliers.Add(supplier);
            return CreatedAtRoute("GetSupplierById", new { id = supplier.Id}, supplier);
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateSupplier([FromBody] Supplier supplier, int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            var toUpdate = _seeder.Suppliers.FirstOrDefault(s => s.Id == id);
            toUpdate.Name = supplier.Name;
            toUpdate.Country = supplier.Country;
            return Ok("Supplier updated");
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteSupplier(int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            _seeder.Suppliers.RemoveAt(_seeder.Suppliers.IndexOf(_seeder.Suppliers.FirstOrDefault(s=> s.Id == id)));
            return Ok("supplier deleted");
        }
    }
}
