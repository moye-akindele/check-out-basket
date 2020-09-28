using CheckOutBasketData;
using System.Collections.Generic;

namespace CheckOutBasket.ServiceInterfaces
{
    public interface IVoucherService
    {
        IEnumerable<Voucher> Get();
        Voucher Get(int voucherId);
        IEnumerable<Voucher> GetMultiple(int[] voucherIds);
    }
}
