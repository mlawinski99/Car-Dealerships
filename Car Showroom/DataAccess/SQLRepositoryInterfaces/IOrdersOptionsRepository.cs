using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IOrdersOptionsRepository
    {
        public void Add(OrdersOptions orderOptions);
        public void Update(OrdersOptions ordersOptionsUpdate);
        public void Delete(int id);
        public OrdersOptions Get(int id);
        public List<OrdersOptions> GetOrdersOptionsList();
    }
}
