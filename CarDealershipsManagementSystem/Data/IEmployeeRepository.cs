using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IEmployeeRepository
    {
        Employee Add(Employee employee);
        Employee Update(Employee employeeUpdate);
        Employee Delete(int id);
        List<Employee> GetEmployeeList();
        int GetEmployeeId(string appUserId);
        Employee GetEmployeeByApplicationUserId(string appUserId);
        List<Employee> GetEmployeeListForEmployeeDealership(Employee employee);
    }
}
