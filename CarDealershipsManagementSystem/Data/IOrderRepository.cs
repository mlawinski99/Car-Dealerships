using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IOrderRepository
    {
        Order Add(Order order);
        Order Delete(int id);
        Order GetOrderById(int id);
        List<Order> GetOrderList(Employee employee);
        List<Order> GetOrderList();
    }
}
