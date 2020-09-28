using CheckOutBasketData.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckOutBasketData.Repositories
{
    public class VoucherRepository : IVoucherRepository
    {
        private static readonly Voucher[] Vouchers = new[]
        {
            new Voucher { Id = 1, Name = "£5 off", Type = VoucherType.Gift, DiscountPrice = 5, Condition = "", },
            new Voucher { Id = 2, Name = "Head Gear", Type = VoucherType.Offer, DiscountPrice = 5, Condition = "Head Gear in baskets over £50.00", },
            new Voucher { Id = 3, Name = "Basket-50", Type = VoucherType.Gift, DiscountPrice = 5, Condition = "Basket is over £50.00", }
        };

        public VoucherRepository()
        {

        }

        public IEnumerable<Voucher> Get()
        {
            return Vouchers;
        }

        public Voucher Get(int voucherId)
        {
            Voucher seletedVoucher = Vouchers.FirstOrDefault(v => v.Id == voucherId);
            return seletedVoucher;
        }

        public IEnumerable<Voucher> GetMultiple(int[] voucherIds)
        {
            var retrievedVouchers = Vouchers.Where(v => voucherIds.Contains(v.Id));
            return retrievedVouchers;
        }
    }
}
