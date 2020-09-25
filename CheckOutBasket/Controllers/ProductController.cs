using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckOutBasketData.Enum;
using CheckOutBasketData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOutBasket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly Product[] Products = new[]
        {
            new Product
            {
                Id = 1,
                Name = "Hat 1",
                Category = ProductCategory.Hat,
                Price = 10.50,
            },

            new Product
            {
                Id = 2,
                Name = "Jumper 1",
                Category = ProductCategory.Top,
                Price = 54.65,
            },

            new Product
            {
                Id = 3,
                Name = "Hat 2",
                Category = ProductCategory.Hat,
                Price = 25.00,
            },

            new Product
            {
                Id = 4,
                Name = "Jumper 2",
                Category = ProductCategory.Top,
                Price = 26.00,
            },

            new Product
            {
                Id = 5,
                Name = "Head Light",
                Category = ProductCategory.HeadGear,
                Price = 3.50,
            },

            new Product
            {
                Id = 6,
                Name = "£30 Gift Voucher",
                Category = ProductCategory.Voucher,
                Price = 3.50,
            },
        };

        public ProductController()
        {

        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return Products;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
