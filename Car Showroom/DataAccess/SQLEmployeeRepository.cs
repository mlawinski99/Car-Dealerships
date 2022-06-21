using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLEmployeeRepository : IEmployeeRepository
    {
        private readonly CarDealershipsContext dbContext;

        public SQLEmployeeRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Employee Add(Employee employee)
        {
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = dbContext.Employee.Find(id);
            if (employee != null)
            {
                dbContext.Remove(employee);
                dbContext.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployeeById(string appUserId)
        {
            var employee = (Employee)dbContext.Employee.Where(c => c.ApplicationUserId == appUserId);
            return employee;
        }

        public int GetEmployeeId(string appUserId)
        {
            var result = dbContext.Employee.Where(c => c.ApplicationUserId == appUserId).FirstOrDefault<Employee>();
            int id = result.Id;
            return id;
        }

        public List<Employee> GetEmployeeList()
        {
            var employeeList = dbContext.Employee.ToList();
            return employeeList;
        }

        public Employee Update(Employee employeeUpdate)
        {
            var employee = dbContext.Employee.Attach(employeeUpdate);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return employeeUpdate;
        }
    }
}
