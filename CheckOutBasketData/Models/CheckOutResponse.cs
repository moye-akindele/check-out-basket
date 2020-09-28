using System.Collections.Generic;

namespace CheckOutBasketData.Models
{
    public class CheckOutResponse
    {
        public string Messages { get; set; }
        public IEnumerable<Product> RetrievedProducts { get; set; }
        public IEnumerable<Voucher> RetrievedVouchers { get; set; }
        
    }
}
