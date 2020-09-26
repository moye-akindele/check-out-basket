using System;
using System.Collections.Generic;
using System.Text;

namespace CheckOutBasketData.RepositoryInterfaces
{
    public interface IVoucherRepository
    {
        IEnumerable<Voucher> Get();
        Voucher Get(int voucherId);
        IEnumerable<Voucher> GetMultiple(int[] voucherIds);
    }
}
