using CheckOutBasketData.Models;
using System.Collections.Generic;

namespace CheckOutBasket.ServiceInterfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> Get();
        public Product Get(int productId);
        IEnumerable<Product> GetMultiple(int[] productIds);
    }
}
