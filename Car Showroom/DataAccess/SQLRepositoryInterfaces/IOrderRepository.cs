using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IOrderRepository
    {
        public void Add(Order order);
        public void Update(Order orderUpdate);
        public void Delete(int id);
        public Order Get(int id);
        public List<Order> GetOrderList();
        public List<Option> GetOptionsChosenInOrder(Order order);
    }
}
