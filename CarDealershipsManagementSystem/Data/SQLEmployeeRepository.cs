using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
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

        public Employee GetEmployeeById(string appUserId)
        {
            var employee = dbContext.Employees.Where(c => c.ApplicationUser.Id == appUserId).FirstOrDefault();
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
            var employeeList = dbContext.Employees.ToList();
            return employeeList;
        }

        public List<Employee> GetEmployeeList(Employee employee)
        {
            var employeeList = dbContext.Employees.Where(e => e.Dealership == employee.Dealership).ToList();
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
