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
        public ActionResult<IEnumerable<Voucher>> Get()
        {
            return Ok(_service.Get());
        }

        // GET api/<VouchersController>/5
        [HttpGet("{id}")]
        public ActionResult<Voucher> Get(int voucherId)
        {
            var selectedVoucher = _service.Get(voucherId);

            if (selectedVoucher == null)
            {
                return NotFound();
            }

            return Ok(selectedVoucher);
        }

        [HttpGet("GetMultiple")]
        public ActionResult<IEnumerable<Voucher>> GetMultiple(int[] voucherIds)
        {
            var selectedVouchers = _service.GetMultiple(voucherIds);

            if (selectedVouchers == null)
            {
                return NotFound();
            }

            return Ok(selectedVouchers);
        }
    }
}
