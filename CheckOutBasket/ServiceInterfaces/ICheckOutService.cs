using CheckOutBasketData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckOutBasket.ServiceInterfaces
{
    public interface ICheckOutService
    {
        CheckOutResponse GetCheckOutResponse(CheckOutRequest request);
    }
}
