using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly CarDealershipsContext dbContext;

        public SQLCustomerRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Customer Add(Customer customer)
        {
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer customer = dbContext.Customer.Find(id);
            if (customer != null)
            {
                dbContext.Remove(customer);
                dbContext.SaveChanges();
            }
            return customer;
        }

        public int GetCustomerId(string appUserId)
        {
            var result = (Customer)dbContext.Customer.Where(c => c.ApplicationUserId == appUserId);
            int id = result.Id;
            return id;
        }

        public List<Customer> GetCustomerList()
        {
            var customerList = dbContext.Customer.ToList();
            return customerList;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customer = dbContext.Customer.Attach(customerUpdate);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return customerUpdate;
        }
    }
}
