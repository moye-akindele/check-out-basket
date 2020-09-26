using CheckOutBasketData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutBasket.ServiceInterfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> Get();
        public Product Get(int productId);
        IEnumerable<Product> GetMultiple(int[] productIds);
    }
}
