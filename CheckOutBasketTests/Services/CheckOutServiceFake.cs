using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using CheckOutBasketData.Helpers;
using CheckOutBasketData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutBasketTests.Services
{
    public class CheckOutServiceFake : ICheckOutService
    {
        IProductService _productService;
        IVoucherService _voucherService;

        public CheckOutServiceFake()
        {
            _productService = new ProductServiceFake();
            _voucherService = new VoucherServiceFake();
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
            StringBuilder checkOutMessage = new StringBuilder();
            foreach (Product product in retrievedProducts)
            {
                checkOutMessage.Append($"{product.Name} @ £{product.Price}");
                checkOutMessage.Append(Environment.NewLine);
            }
            checkOutMessage.Append("------------------------------------------");
            checkOutMessage.Append(Environment.NewLine);

            foreach (Voucher voucher in retrievedVouchers)
            {
                checkOutMessage.Append($"{voucher.Name} @ £{voucher.Type} applied");
                checkOutMessage.Append(Environment.NewLine);
            }
            checkOutMessage.Append("------------------------------------------");
            checkOutMessage.Append(Environment.NewLine);

            double amendedTotalPrice;
            string voucherMessage;

            VoucherHandler voucherHandler = new VoucherHandler(retrievedProducts, retrievedVouchers);
            voucherHandler.ApplyVouchers(out amendedTotalPrice, out voucherMessage);
            checkOutMessage.Append($"Total = £{amendedTotalPrice}");
            checkOutMessage.Append(voucherMessage);

            CheckOutResponse response = new CheckOutResponse()
            {
                Messages = checkOutMessage.ToString(),
                RetrievedProducts = retrievedProducts,
                RetrievedVouchers = retrievedVouchers
            };

            return response;
        }
    }
}
