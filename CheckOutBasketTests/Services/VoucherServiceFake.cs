using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CheckOutBasketTests.Services
{
    public class VoucherServiceFake : IVoucherService
    {
        private readonly List<Voucher> _vouchers;

        public VoucherServiceFake()
        {
            _vouchers = new List<Voucher>()
            {
                new Voucher { Id = 1, Name = "£5 off", Type = VoucherType.Gift, DiscountPrice = 5, Condition = "", },
                new Voucher { Id = 2, Name = "Head Gear", Type = VoucherType.Offer, DiscountPrice = 5, Condition = "Head Gear in baskets over £50.00", },
                new Voucher { Id = 3, Name = "Basket-50", Type = VoucherType.Gift, DiscountPrice = 5, Condition = "Basket is over £50.00", }
            };
        }

        public IEnumerable<Voucher> Get()
        {
            return _vouchers;
        }

        public Voucher Get(int voucherId)
        {
            Voucher seletedVouchers = _vouchers.FirstOrDefault(v => v.Id == voucherId);
            return seletedVouchers;
        }

        public IEnumerable<Voucher> GetMultiple(int[] voucherIds)
        {
            var retrievedVouchers = _vouchers.Where(v => voucherIds.Contains(v.Id)).ToList();
            return retrievedVouchers;
        }
    }
}
