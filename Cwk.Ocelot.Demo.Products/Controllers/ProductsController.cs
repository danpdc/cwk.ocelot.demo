using Cwk.Ocelot.Demo.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cwk.Ocelot.Demo.Products.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private Seeder _seeder;
        private readonly IHttpContextAccessor _ctxAccessor;
        public ProductsController(Seeder seeder, IHttpContextAccessor ctxAccesor)
        {
            _seeder = seeder;
            _ctxAccessor = ctxAccesor;
        }

        public IActionResult GetProducts()
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            return Ok(_seeder.Products);
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] Product product)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            _seeder.Products.Add(product);
            return CreatedAtRoute("GetProductById", new{ id = product.Id }, product);
        }

        [Route("{id}", Name ="GetProductById")]
        public IActionResult GetProductById(int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            return Ok(_seeder.Products.FirstOrDefault(p => p.Id == id));
        }

        [Route("{id}")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product product, int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            var existing = _seeder.Products.FirstOrDefault(p => p.Id == id);
            existing.Code = product.Code;
            existing.Description = product.Description;
            existing.Name = product.Name;
            existing.Price = product.Price;
            return Ok("Product updated");
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            KeyValuePair<string, StringValues>[]
                requestHeaders = _ctxAccessor.HttpContext.Request.Headers.ToArray();
            var headerValues = HttpHeadersHelper.ExtractHeaders(requestHeaders);
            HttpHeadersHelper.DisplayHeaders(headerValues);
            var toRemove = _seeder.Products.FirstOrDefault(p=> p.Id == id);
            _seeder.Products.Remove(toRemove);
            return Ok("Product deleted");
        }
    }
}
