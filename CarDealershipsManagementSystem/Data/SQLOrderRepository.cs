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

        public Order GetOrderById(int id)
        {

            var order = dbContext.Orders
                .Where(o => o.OrderId == id).FirstOrDefault();

            return order;
        }

        public List<Order> GetOrderList(Employee employee)
        {
            List<Order> orderList = dbContext.Orders.Where(o => o.DealershipEmployee.Dealership == employee.Dealership).ToList();
            return orderList;
        }
        public List<Order> GetOrderList()
        {
            List<Order> orderList = dbContext.Orders.ToList();
            return orderList;
        }

        public List<Order> GetOrdersForDealershipEmployee(Employee employee)
        {
            return dbContext
                .Orders
                .Include(o => o.Customer)
                .Include(o => o.DealershipEmployee)
                .Include(o => o.ServiceEmployee)
                .Include(o => o.Cars)
                .Include(o => o.Options)
                .Where(o => o.DealershipEmployee == employee)
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
