using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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
        public ActionResult<IEnumerable<Product>> Get()
        {
            return Ok(_service.Get());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var selectedProduct = _service.Get(id);

            if (selectedProduct == null)
            {
                return NotFound();
            }

            return Ok(selectedProduct);
        }

        [HttpGet("GetMultiple")]
        public ActionResult<IEnumerable<Product>> GetMultiple(int[] productIds)
        {
            var selectedProducts = _service.GetMultiple(productIds);

            if (selectedProducts == null)
            {
                return NotFound();
            }

            return Ok(selectedProducts);
        }
    }
}
