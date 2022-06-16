using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLOrderRepository : IOrderRepository
    {
        private readonly CarDealershipsContext dbContext;

        public SQLOrderRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Order Add(Order order)
        {
            dbContext.Order.Add(order);
            dbContext.SaveChanges();
            return order;
        }

        public Order Delete(int id)
        {
            Order order = dbContext.Order.Find(id);
            if (order != null)
            {
                dbContext.Remove(order);
                dbContext.SaveChanges();
            }
            return order;
        }

        public List<Order> GetOrderList()
        {
            List<Order> orderList = dbContext.Order.ToList();
            return orderList;
        }
    }
}
