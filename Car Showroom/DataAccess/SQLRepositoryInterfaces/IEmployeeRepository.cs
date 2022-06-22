using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IEmployeeRepository
    {
        public void Add(Employee employee);
        public void Update(Employee employeeUpdate);
        public void Delete(int id);
        public Employee Get(int id);
        public List<Employee> GetEmployeeList();
        public int GetEmployeeAppUserId(string appUserId);
        public Employee GetEmployeeByAppUserId(string appUserId);
    }
}
