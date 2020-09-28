using CheckOutBasketData.Models;

namespace CheckOutBasket.ServiceInterfaces
{
    public interface ICheckOutService
    {
        CheckOutResponse GetCheckOutResponse(CheckOutRequest request);
    }
}
