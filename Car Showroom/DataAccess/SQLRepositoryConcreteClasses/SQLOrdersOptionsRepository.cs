using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLOrdersOptionsRepository : IOrdersOptionsRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLOrdersOptionsRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(OrdersOptions orderOptions)
        {
            dbContext.OrdersOptions.Add(orderOptions);
            dbContext.SaveChanges();
        }
        public void Update(OrdersOptions ordersOptionsUpdate)
        {
            var ordersOptions = dbContext.OrdersOptions.Attach(ordersOptionsUpdate);
            ordersOptions.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            OrdersOptions ordersOptions = dbContext.OrdersOptions.Find(id);
            if (ordersOptions != null)
            {
                dbContext.Remove(ordersOptions);
                dbContext.SaveChanges();
            }
        }
        public OrdersOptions Get(int id)
        {
            return dbContext.OrdersOptions.FindAsync(id).Result;
        }
        public List<OrdersOptions> GetOrdersOptionsList()
        {
            return dbContext.OrdersOptions.ToList();
        }
    }
}
