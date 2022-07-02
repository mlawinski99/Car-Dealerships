﻿using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
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
        public List<Order> GetOrderList(Employee employee)
        {
            List<Order> orderList = dbContext.Orders.Where(o => o.DealershipEmployee.Dealership == employee.Dealership).ToList();
            return orderList;
        }
    }
}
