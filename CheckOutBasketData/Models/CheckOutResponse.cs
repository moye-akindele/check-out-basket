using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutBasketData.Models
{
    public class CheckOutResponse
    {
        public string Messages { get; set; }
        public IEnumerable<Product> RetrievedProducts { get; set; }
        public IEnumerable<Voucher> RetrievedVouchers { get; set; }
        
    }
}
