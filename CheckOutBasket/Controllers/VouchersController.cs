using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOutBasket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VouchersController : ControllerBase
    {
        private readonly IVoucherService _service;

        public VouchersController(IVoucherService service)
        {
            _service = service;
        }

        // GET: api/<VouchersController>
        [HttpGet]
        public IEnumerable<Voucher> Get()
        {
            return _service.Get();
        }

        // GET api/<VouchersController>/5
        [HttpGet("{id}")]
        public Voucher Get(int voucherId)
        {
            return _service.Get(voucherId);
        }

        [HttpGet("GetMultiple")]
        public IEnumerable<Voucher> GetMultiple(int[] voucherIds)
        {
            return _service.GetMultiple(voucherIds);
        }
    }
}
