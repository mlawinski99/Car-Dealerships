using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SQLOrderRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Order Add(Order order)
        {
            dbContext.Orders.Add(order);
            dbContext.SaveChanges();
            return order;
        }
        public Order Delete(int id)
        {
            Order order = dbContext.Orders.Find(id);
            if (order != null)
            {
                dbContext.Remove(order);
                dbContext.SaveChanges();
            }
            return order;
        }

        public Order ChangeStatus(Order order, Employee employee, List<Employee> employeeList)
        {
            if (order.OrderStatus == OrderStatuses.Nowe.ToString())
            {
                order.OrderStatus = OrderStatuses.Zaakceptowane.ToString();
                order.DealershipEmployee = employee;
                var random = new Random();
                int index = random.Next(employeeList.Count);
                order.ServiceEmployee = employeeList[index];
            }
            else if (order.OrderStatus == OrderStatuses.Zaakceptowane.ToString())
                order.OrderStatus = OrderStatuses.WSerwisie.ToString();
            else if (order.OrderStatus == OrderStatuses.WSerwisie.ToString())
                order.OrderStatus = OrderStatuses.Gotowe.ToString();
            else if (order.OrderStatus == OrderStatuses.Gotowe.ToString())
                order.OrderStatus = OrderStatuses.Wyslane.ToString();

     //       var model = dbContext.Orders.Attach(order);
       //     model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return order;
        }
        public Order GetOrderById(int id)
        {

            var order = dbContext.Orders
                .Where(o => o.OrderId == id).FirstOrDefault();

            return order;
        }

        public List<Order> GetOrderList()
        {
            List<Order> orderList = dbContext
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.DealershipEmployee)
                .Include(o => o.ServiceEmployee)
                .Include(o => o.Cars)
                .Include(o => o.Options)
                .ToList();
            return orderList;
        }

        public List<Order> GetOrdersForDealershipEmployee(Employee employee)
        {
            var dealer = new Dealership();
            return dbContext
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.DealershipEmployee)
                .Include(o => o.ServiceEmployee)
                .Include(o => o.Cars)
                .Include(o => o.Options)
                .ToList();
        }

        public List<Order> GetOrdersForServiceEmployee(Employee employee)
        {
            return dbContext
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.DealershipEmployee)
                .Include(o => o.ServiceEmployee)
                .Include(o => o.Cars)
                .Include(o => o.Options)
                .Where(o => o.ServiceEmployee == employee)
                .ToList();
        }
    }
}
