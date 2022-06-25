using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ICustomerRepository
    {
        Customer Add(Customer customer);
        Customer Update(Customer customer);
        Customer Delete(int id);
        int GetCustomerId(string appUserId);
        List<Customer> GetCustomerList();
    }
}
