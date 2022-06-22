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
        public void Add(Customer customer)
        {
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
        }
        public void Update(Customer customerUpdate)
        {
            var customer = dbContext.Customer.Attach(customerUpdate);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Customer customer = dbContext.Customer.Find(id);
            if (customer != null)
            {
                dbContext.Remove(customer);
                dbContext.SaveChanges();
            }
        }
        public Customer Get(int id)
        {
            return dbContext.Customer.FindAsync(id).Result;
        }
        public List<Customer> GetCustomerList()
        {
            return dbContext.Customer.ToList();
        }
        public int GetCustomerAppUserId(string appUserId)
        {
            var result = (Customer)dbContext.Customer.Where(c => c.ApplicationUserId == appUserId);
            int id = result.Id;
            return id;
        }
    }
}
