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
        public void Add(Employee employee)
        {
            dbContext.Employee.Add(employee);
            dbContext.SaveChanges();
        }
        public void Update(Employee employeeUpdate)
        {
            var employee = dbContext.Employee.Attach(employeeUpdate);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Employee employee = dbContext.Employee.Find(id);
            if (employee != null)
            {
                dbContext.Remove(employee);
                dbContext.SaveChanges();
            }
        }
        public Employee Get(int id)
        {
            return dbContext.Employee.FindAsync(id).Result;
        }
        public List<Employee> GetEmployeeList()
        {
            return dbContext.Employee.ToList();
        }
        public Employee GetEmployeeByAppUserId(string appUserId)
        {
            var employee = dbContext.Employee.Where(c => c.ApplicationUserId == appUserId).ToList();
            return employee.FirstOrDefault();
        }
        public int GetEmployeeAppUserId(string appUserId)
        {
            var result = dbContext.Employee.Where(c => c.ApplicationUserId == appUserId).ToList();
            int id = result.FirstOrDefault().Id;
            return id;
        }
    }
}
