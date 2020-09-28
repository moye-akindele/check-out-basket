using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData.Enum;
using CheckOutBasketData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOutBasketTests.Services
{
    public class ProductServiceFake : IProductService
    {
        private readonly List<Product> _products;

        public ProductServiceFake()
        {
            _products = new List<Product>()
            {
                new Product { Id = 1, Name = "Hat 1", Category = ProductCategory.Hat, Price = 10.50, },
                new Product { Id = 2, Name = "Jumper 1", Category = ProductCategory.Top, Price = 54.65, },
                new Product { Id = 3, Name = "Hat 2", Category = ProductCategory.Hat, Price = 25.00, },
                new Product { Id = 4, Name = "Jumper 2", Category = ProductCategory.Top, Price = 26.00, },
                new Product { Id = 5, Name = "Head Light", Category = ProductCategory.HeadGear, Price = 3.50, },
                new Product { Id = 6, Name = "£30 Gift Voucher", Category = ProductCategory.Voucher, Price = 30.00, },
            };
        }

        public IEnumerable<Product> Get()
        {
            return _products;
        }

        public Product Get(int productId)
        {
            Product seletedProduct = _products.FirstOrDefault(p => p.Id == productId);
            return seletedProduct;
        }

        public IEnumerable<Product> GetMultiple(int[] productIds)
        {
            var retrievedProducts = _products.Where(p => productIds.Contains(p.Id)).ToList();
            return retrievedProducts;
        }
    }
}
