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
        private SQLOptionRepository OptionRepository;
        public SQLOrderRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
            OptionRepository = new SQLOptionRepository(dbContext);
        }
        public void Add(Order order)
        {
            dbContext.Order.Add(order);
            dbContext.SaveChanges();
        }
        public void Update(Order orderUpdate)
        {
            var order = dbContext.Order.Attach(orderUpdate);
            order.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Order order = dbContext.Order.Find(id);
            if (order != null)
            {
                dbContext.Remove(order);
                dbContext.SaveChanges();
            }
        }
        public Order Get(int id)
        {
            return dbContext.Order.FindAsync(id).Result;
        }
        public List<Order> GetOrderList()
        {
            return dbContext.Order.ToList();
        }
        public List<Option> GetOptionsChosenInOrder(Order order)
        {
            List<OrdersOptions> orderOptionList = order.OrdersOptions.ToList();
            List<Option> optionList = new List<Option>();
            foreach (OrdersOptions oo in orderOptionList)
            {
                optionList.Add(OptionRepository.Get(oo.OptionId));
            }
            return optionList;
        }
    }
}
