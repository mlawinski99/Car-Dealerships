using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ICustomerRepository
    {
        public void Add(Customer customer);
        public void Update(Customer customer);
        public void Delete(int id);
        public Customer Get(int id);
        public List<Customer> GetCustomerList();
        public int GetCustomerAppUserId(string appUserId);
    }
}
