using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData.Enum;
using CheckOutBasketData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOutBasket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return _service.Get();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public Product Get(int id)
        {
            return _service.Get(id);
        }

        [HttpGet("GetMultiple")]
        public IEnumerable<Product> GetMultiple(int[] productIds)
        {
            return _service.GetMultiple(productIds);
        }
    }
}
