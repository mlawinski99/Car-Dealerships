using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee Update(Employee employeeUpdate);
        Employee Delete(int id);
        List<Employee> GetEmployeeList();
        int GetEmployeeId(string appUserId);
        Employee GetEmployeeById(string appUserId);
        List<Employee> GetEmployeeList(Employee employee);
    }
}
