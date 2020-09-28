namespace CheckOutBasketData.Models
{
    public class CheckOutRequest
    {
        public int[] ProductIds { get; set; }
        public int[] VoucherIds { get; set; }
    }
}
