using CheckOutBasketData.Models;
using System.Collections.Generic;

namespace CheckOutBasketData.RepositoryInterfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product Get(int productId);
        IEnumerable<Product> GetMultiple(int[] productIds);
    }
}
