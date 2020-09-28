using CheckOutBasket.ServiceInterfaces;
using CheckOutBasketData;
using CheckOutBasketData.RepositoryInterfaces;
using System.Collections.Generic;

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
