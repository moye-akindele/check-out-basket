using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutBasketData.Models
{
    public class CheckOutRequest
    {
        public int Id { get; set; }
        public int[] ProductIds { get; set; }
        public int[] VoucherIds { get; set; }
    }
}
