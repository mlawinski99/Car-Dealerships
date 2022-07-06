using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLCustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLCustomerRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Customer Add(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return customer;
        }

        public Customer Delete(int id)
        {
            Customer customer = dbContext.Customers.Find(id);
            if (customer != null)
            {
                dbContext.Remove(customer);
                dbContext.SaveChanges();
            }
            return customer;
        }

        public Customer GetCustomerByAppUserId(string appUserId)
        {
            var customer = dbContext
                .Customers
                .Where(c => c.ApplicationUser.Id == appUserId)
                .FirstOrDefault();
            return customer;
        }

        public int GetCustomerId(string appUserId)
        {
            var result = dbContext.Customers.Where(c => c.ApplicationUser.Id == appUserId).FirstOrDefault();
            int id = result.CustomerId;
            return id;
        }

        public List<Customer> GetCustomerList()
        {
            var customerList = dbContext
                .Customers
                .Include(c => c.Orders)
                .ThenInclude(o => o.DealershipEmployee)
                .ThenInclude(e => e.Dealership)
                .Include(c => c.ApplicationUser)
                .ThenInclude(c => c.Address)
                .ToList();
            return customerList;
        }

        public Customer Update(Customer customerUpdate)
        {
            var customer = dbContext.Customers.Attach(customerUpdate);
            customer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return customerUpdate;
        }
    }
}
