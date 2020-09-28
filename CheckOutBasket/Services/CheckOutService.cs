using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using CheckOutBasketData.Helpers;
using CheckOutBasketData.Models;
using System;
using System.Text;

namespace CheckOutBasket.Services
{
    public class CheckOutService : ICheckOutService
    {
        private readonly IProductService _productService;
        private readonly IVoucherService _voucherService;

        public CheckOutService(IProductService productService, IVoucherService voucherService)
        {
            _productService = productService;
            _voucherService = voucherService;
        }

        public CheckOutResponse GetCheckOutResponse(CheckOutRequest request)
        {
            var retrievedProducts = _productService.GetMultiple(request.ProductIds);
            var retrievedVouchers = _voucherService.GetMultiple(request.VoucherIds);

            if (retrievedProducts == null)
            {
                throw new ArgumentException($"Failed to retrieve products.");
            }

            // Construct Message
            StringBuilder checkoutMessage = new StringBuilder();
            foreach (Product product in retrievedProducts)
            {
                checkoutMessage.Append($"{product.Name} @ £{product.Price}");
                checkoutMessage.Append(Environment.NewLine);
            }
            checkoutMessage.Append("------------------------------------------");
            checkoutMessage.Append(Environment.NewLine);

            foreach (Voucher voucher in retrievedVouchers)
            {
                checkoutMessage.Append($"{voucher.Name} @ £{voucher.Type} applied");
                checkoutMessage.Append(Environment.NewLine);
            }
            checkoutMessage.Append("------------------------------------------");
            checkoutMessage.Append(Environment.NewLine);

            // Apply vouchers.
            double amendedTotalPrice;
            string voucherMessage;

            VoucherHandler voucherHandler = new VoucherHandler(retrievedProducts, retrievedVouchers);
            voucherHandler.ApplyVouchers(out amendedTotalPrice, out voucherMessage);
            checkoutMessage.Append($"Total = £{amendedTotalPrice}");
            checkoutMessage.Append(voucherMessage);

            CheckOutResponse response = new CheckOutResponse()
            {
                Messages = checkoutMessage.ToString(),
                RetrievedProducts = retrievedProducts,
                RetrievedVouchers = retrievedVouchers
            };

            return response;
        }
    }
}
