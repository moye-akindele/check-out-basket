using CheckOutBasketData.Enum;
using CheckOutBasketData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOutBasketData.Helpers
{
    public class VoucherHandler
    {
        IEnumerable<Product> Products;
        IEnumerable<Voucher> Vouchers;
        double InitialTotalPrice;
        double AmendedTotalPrice;

        public VoucherHandler(IEnumerable<Product>  products, IEnumerable<Voucher> vouchers)
        {
            Products = products;
            Vouchers = vouchers;
            GetInitialTotal();
        }

        public void ApplyVouchers(out double amendedTotalPrice, out string voucherMessage)
        {
            voucherMessage = string.Empty;
            AmendedTotalPrice = InitialTotalPrice;

            var voucherProductsTotal = Products.Where(p => p.Category == ProductCategory.Voucher).Select(vp => vp.Price).Sum();
            if (voucherProductsTotal > 0)
            {
                AmendedTotalPrice -= voucherProductsTotal;
            }

            foreach (Voucher voucher in Vouchers)
            {
                switch (voucher.Id)
                {
                    case 1:
                        var voucherOneDeductionPrice = Vouchers.First(v => v.Id == voucher.Id).DiscountPrice;

                        AmendedTotalPrice = AmendedTotalPrice > voucherOneDeductionPrice ? AmendedTotalPrice - voucherOneDeductionPrice : 0;

                        break;
                    case 2:
                        var headGearList = Products.Where(p => p.Category == ProductCategory.HeadGear).ToArray();

                        if (headGearList != null || headGearList.Length == 0)
                        {
                            voucherMessage += "Message: There are no products in your basket applicable to Head Gear voucher.";
                        }

                        if (InitialTotalPrice > 50 && headGearList != null && headGearList.Length > 0)
                        {
                            var HeadGearTotalPrice = headGearList.Select(rp => rp.Price).Sum();
                            var voucherTwoDeductionPrice = Vouchers.First(v => v.Id == voucher.Id).DiscountPrice;

                            voucherTwoDeductionPrice = HeadGearTotalPrice < voucherTwoDeductionPrice ? HeadGearTotalPrice : voucherTwoDeductionPrice;
                            AmendedTotalPrice = AmendedTotalPrice > voucherTwoDeductionPrice ? AmendedTotalPrice - voucherTwoDeductionPrice : 0;
                        }
                        break;
                    case 3:
                        if ((InitialTotalPrice - voucherProductsTotal) > 50)
                        {
                            var voucherThreeDeductionPrice = Vouchers.First(v => v.Id == voucher.Id).DiscountPrice;

                            AmendedTotalPrice = AmendedTotalPrice > voucherThreeDeductionPrice ? AmendedTotalPrice - voucherThreeDeductionPrice : 0;
                        }
                        else
                        {
                            var remainingCost = 50 - (InitialTotalPrice - voucherProductsTotal);
                            voucherMessage += $"Message: You have not reached the spend threshold for Basket-50 voucher. Spend another £{remainingCost} to " +
                                "receive £5.00 discount from your basket total.";
                        }
                        break;
                    default:
                        break;
                }
            }

            if (voucherProductsTotal > 0)
            {
                AmendedTotalPrice += voucherProductsTotal;
            }
            amendedTotalPrice = Math.Round(AmendedTotalPrice, 2);
        }

        void GetInitialTotal()
        {
            InitialTotalPrice = Products.Select(rp => rp.Price).Sum();
        }
    }
}
