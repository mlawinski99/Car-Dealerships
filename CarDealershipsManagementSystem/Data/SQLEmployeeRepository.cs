using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLEmployeeRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee Add(Employee employee)
        {
            dbContext.Employees.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = dbContext.Employees.Find(id);
            if (employee != null)
            {
                dbContext.Remove(employee);
                dbContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployeeByApplicationUserId(string appUserId)
        {
            var employee = dbContext
                .Employees
                .Where(c => c.ApplicationUser.Id == appUserId)
                .Include(e => e.Dealership)
                .Include(e => e.DealershipOrders)
                .Include(e => e.ServiceOrders)
                .FirstOrDefault();
            return employee;
        }

        public int GetEmployeeId(string appUserId)
        {
            var result = dbContext.Employees.Where(c => c.ApplicationUser.Id == appUserId).FirstOrDefault();
            int id = result.EmployeeId;
            return id;
        }

        public List<Employee> GetEmployeeList()
        {
            var employeeList = dbContext
                .Employees
                .Include(e => e.ApplicationUser)
                .Include(e => e.Dealership)
                .ToList();
            return employeeList;
        }

        public List<Employee> GetEmployeeListForEmployeeDealership(Employee employee)
        {
            var employeeList = dbContext.
                Employees
                .Where(e => e.Dealership == employee.Dealership)
                .Where(e => e.EmployeeId != employee.EmployeeId)
                .Include(e => e.ApplicationUser)
                .ToList();
            return employeeList;
        }

        public Employee Update(Employee employeeUpdate)
        {
            var employee = dbContext.Employees.Attach(employeeUpdate);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return employeeUpdate;
        }
    }
}
