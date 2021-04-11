using cozaStore.Models;
using System.Collections.Generic;

namespace cozaStore.BusinessLogicLayer
{
    public interface ICheckOutServices 
    {
        void CheckOut(Order order, List<OrderDetail> orderDetails);
    }
}
