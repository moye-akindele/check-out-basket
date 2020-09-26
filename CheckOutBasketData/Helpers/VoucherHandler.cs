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

        public double ApplyVouchers()
        {
            AmendedTotalPrice = InitialTotalPrice;

            var voucherProductsTotal = Products.Where(p => p.Category == ProductCategory.Voucher).Select(vp => vp.Price).Sum();
            if (voucherProductsTotal > 0)
            {
                AmendedTotalPrice -= voucherProductsTotal;
            }

            
            //int[] voucherIds = Vouchers.Select(v => v.Id).ToArray();

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
                        break;
                    default:
                        break;
                }
            }

            if (voucherProductsTotal > 0)
            {
                AmendedTotalPrice += voucherProductsTotal;
            }
            return Math.Round(AmendedTotalPrice, 2);
        }

        void GetInitialTotal()
        {
            InitialTotalPrice = Products.Select(rp => rp.Price).Sum();
        }
    }
}
