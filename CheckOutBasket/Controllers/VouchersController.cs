using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckOutBasketData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOutBasket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private static readonly Voucher[] Vouchers = new[]
        {
            new Voucher
            {
                Id = 1,
                Name = "£5 off",
                Type = VoucherType.Gift,
                DiscountPrice = 5,
                Condition = "",
            },

            new Voucher
            {
                Id = 2,
                Name = "£5 off Head Gear",
                Type = VoucherType.Offer,
                DiscountPrice = 5,
                Condition = "Head Gear in baskets over £50.00",
            },

            new Voucher
            {
                Id = 3,
                Name = "£5 off basket",
                Type = VoucherType.Gift,
                DiscountPrice = 5,
                Condition = "Basket is over £50.00",
            }
        };

        public VouchersController()
        {

        }

        // GET: api/<VouchersController>
        [HttpGet]
        public IEnumerable<Voucher> Get()
        {
            return Vouchers;
        }

        // GET api/<VouchersController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VouchersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VouchersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VouchersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
