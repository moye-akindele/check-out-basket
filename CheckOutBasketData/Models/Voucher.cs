namespace CheckOutBasketData
{
    public class Voucher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public VoucherType Type { get; set; }
        public double DiscountPrice { get; set; }
        public string Condition { get; set; }
    }
}
