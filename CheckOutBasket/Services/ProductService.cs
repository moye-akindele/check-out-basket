using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData.Models;
using CheckOutBasketData.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutBasket.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _respository;
        public ProductService(IProductRepository respository)
        {
            _respository = respository;
        }

        public IEnumerable<Product> Get()
        {
            return _respository.Get();
        }
        public Product Get(int productId)
        {
            return _respository.Get(productId);
        }

        public IEnumerable<Product> GetMultiple(int[] productIds)
        {
            return _respository.GetMultiple(productIds);
        }
    }
}
