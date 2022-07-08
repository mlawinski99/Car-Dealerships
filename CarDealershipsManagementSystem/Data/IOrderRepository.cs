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
        Order Update(Order orderUpdate);
        Order GetOrderById(int id);
        Order ChangeStatus(Order order, Employee employee, List<Employee>? employeeList);
        List<Order> GetOrderList();
        List<Order> GetOrdersForDealershipEmployee(Employee employee);
        List<Order> GetOrdersForServiceEmployee(Employee employee);
    }
}
