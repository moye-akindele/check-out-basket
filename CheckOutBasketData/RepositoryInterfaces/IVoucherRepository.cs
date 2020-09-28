using System.Collections.Generic;

namespace CheckOutBasketData.RepositoryInterfaces
{
    public interface IVoucherRepository
    {
        IEnumerable<Voucher> Get();
        Voucher Get(int voucherId);
        IEnumerable<Voucher> GetMultiple(int[] voucherIds);
    }
}
