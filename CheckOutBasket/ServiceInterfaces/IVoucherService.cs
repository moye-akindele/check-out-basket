using CheckOutBasketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutBasket.ServiceInterfaces
{
    public interface IVoucherService
    {
        IEnumerable<Voucher> Get();
        Voucher Get(int voucherId);
        IEnumerable<Voucher> GetMultiple(int[] voucherIds);
    }
}
