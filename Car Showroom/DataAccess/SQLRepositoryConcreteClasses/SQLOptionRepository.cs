using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLOptionRepository : IOptionRepository
    {
        private readonly CarDealershipsContext dbContext;
        private SQLTrimRepository TrimRepository;
        private SQLOrderRepository OrderRepository;
        public SQLOptionRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
            TrimRepository = new SQLTrimRepository(dbContext);
            OrderRepository = new SQLOrderRepository(dbContext);
        }
        public void Add(Option option)
        {
            dbContext.Option.Add(option);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Option option = dbContext.Option.Find(id);
            if (option != null)
            {
                dbContext.Remove(option);
                dbContext.SaveChanges();
            }
        }
        public void Update(Option optionUpdate)
        {
            var option = dbContext.Option.Attach(optionUpdate);
            option.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public Option Get(int id)
        {
            return dbContext.Option.FindAsync(id).Result;
        }
        public List<Option> GetOptionList()
        {
            return dbContext.Option.ToList();
        }
        public List<Trim> GetTrimsWithOption(Option option)
        {
            List<TrimsOptions> trimsOptionList = option.TrimsOptions.ToList();
            List<Trim> trimList = new List<Trim>();
            foreach (TrimsOptions to in trimsOptionList)
            {
                trimList.Add(TrimRepository.Get(to.TrimId));
            }
            return trimList;
        }
        public List<Order> GetOrdersWithOption(Option option)
        {
            List<OrdersOptions> ordersOptionList = option.OrdersOptions.ToList();
            List<Order> orderList = new List<Order>();
            foreach (OrdersOptions oo in ordersOptionList)
            {
                orderList.Add(OrderRepository.Get(oo.OrderId));
            }
            return orderList;
        }
    }
}
