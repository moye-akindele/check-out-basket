using CheckOutBasketData.Enum;

namespace CheckOutBasketData.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductCategory Category { get; set; }
        public double Price { get; set; }
    }
}
