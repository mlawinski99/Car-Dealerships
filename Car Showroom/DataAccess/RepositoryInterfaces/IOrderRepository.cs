using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order Delete(int id);
        List<Order> GetOrderList();
    }
}
