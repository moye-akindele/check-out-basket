using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using CheckOutBasketData.Repositories;
using CheckOutBasketData.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutBasket.Services
{
    public class VoucherService : IVoucherService
    {
        private readonly IVoucherRepository _respository;

        public VoucherService(IVoucherRepository respository)
        {
            _respository = respository;
        }
        public IEnumerable<Voucher> Get()
        {
            return _respository.Get();
        }
        public Voucher Get(int voucherId)
        {
            return _respository.Get(voucherId);
        }

        public IEnumerable<Voucher> GetMultiple(int[] voucherIds)
        {
            return _respository.GetMultiple(voucherIds);
        }
    }
}
