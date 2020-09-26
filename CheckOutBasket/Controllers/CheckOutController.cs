using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using CheckOutBasketData.Enum;
using CheckOutBasketData.Helpers;
using CheckOutBasketData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CheckOutBasket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CheckOutController : ControllerBase
    {
        //private static readonly Product[] Products = new[]
        //{
        //    new Product
        //    {
        //        Id = 1,
        //        Name = "Hat 1",
        //        Category = ProductCategory.Hat,
        //        Price = 10.50,
        //    },

        //    new Product
        //    {
        //        Id = 2,
        //        Name = "Jumper 1",
        //        Category = ProductCategory.Top,
        //        Price = 54.65,
        //    },

        //    new Product
        //    {
        //        Id = 3,
        //        Name = "Hat 2",
        //        Category = ProductCategory.Hat,
        //        Price = 25.00,
        //    },

        //    new Product
        //    {
        //        Id = 4,
        //        Name = "Jumper 2",
        //        Category = ProductCategory.Top,
        //        Price = 26.00,
        //    },

        //    new Product
        //    {
        //        Id = 5,
        //        Name = "Head Light",
        //        Category = ProductCategory.HeadGear,
        //        Price = 3.50,
        //    },

        //    new Product
        //    {
        //        Id = 6,
        //        Name = "£30 Gift Voucher",
        //        Category = ProductCategory.Voucher,
        //        Price = 30.00,
        //    },
        //};

        //private static readonly Voucher[] Vouchers = new[]
        //{
        //    new Voucher
        //    {
        //        Id = 1,
        //        Name = "£5 off",
        //        Type = VoucherType.Gift,
        //        DiscountPrice = 5,
        //        Condition = "",
        //    },

        //    new Voucher
        //    {
        //        Id = 2,
        //        Name = "Head Gear",
        //        Type = VoucherType.Offer,
        //        DiscountPrice = 5,
        //        Condition = "Head Gear in baskets over £50.00",
        //    },

        //    new Voucher
        //    {
        //        Id = 3,
        //        Name = "Basket-50",
        //        Type = VoucherType.Gift,
        //        DiscountPrice = 5,
        //        Condition = "Basket is over £50.00",
        //    }
        //};

        private readonly ICheckOutService _checkOutService;

        public CheckOutController(ICheckOutService checkOutService)
        {
            _checkOutService = checkOutService;
        }

        public CheckOutResponse Post(CheckOutRequest request)
        {
            var response = _checkOutService.GetCheckOutResponse(request);
            return response;
            //var retrievedProducts = Products.Where(p => request.ProductIds.Contains(p.Id));
            //var retrievedVouchers = Vouchers.Where(v => request.VoucherIds.Contains(v.Id));

            //if (retrievedProducts == null)
            //{
            //    throw new ArgumentException($"Failed to retrieve products.");
            //}
            //// Construct Message
            //StringBuilder checkoutMessage = new StringBuilder();
            //foreach(Product product in retrievedProducts)
            //{
            //    checkoutMessage.Append($"{product.Name} @ £{product.Price}");
            //    checkoutMessage.Append(Environment.NewLine);
            //}
            //checkoutMessage.Append("------------------------------------------");
            //checkoutMessage.Append(Environment.NewLine);

            //foreach (Voucher voucher in retrievedVouchers)
            //{
            //    checkoutMessage.Append($"{voucher.Name} @ £{voucher.Type} applied");
            //    checkoutMessage.Append(Environment.NewLine);
            //}
            //checkoutMessage.Append("------------------------------------------");
            //checkoutMessage.Append(Environment.NewLine);

            //double amendedTotalPrice;
            //string voucherMessage;

            //VoucherHandler voucherHandler = new VoucherHandler(retrievedProducts, retrievedVouchers);
            //voucherHandler.ApplyVouchers(out amendedTotalPrice, out voucherMessage);
            //checkoutMessage.Append($"Total = £{amendedTotalPrice}");
            //checkoutMessage.Append(voucherMessage);

            //CheckOutResponse response = new CheckOutResponse()
            //{
            //    Messages = checkoutMessage.ToString(),
            //    RetrievedProducts = retrievedProducts,
            //    RetrievedVouchers = retrievedVouchers
            //};

            //return response;
        }
    }
}
