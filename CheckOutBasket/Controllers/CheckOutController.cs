using CheckOutBasket.ServiceInterfaces;
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

        public ActionResult<CheckOutResponse> Post(CheckOutRequest request)
        {
            var response = _checkOutService.GetCheckOutResponse(request);
            return Ok(response);
        }
    }
}
