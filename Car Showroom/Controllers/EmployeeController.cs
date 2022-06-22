using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Car_Showroom.DataAccess;
using Car_Showroom.Models;
using Car_Showroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Car_Showroom.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IOrderRepository orderRepository;

        public EmployeeController(
            UserManager<ApplicationUser> userManager,
            IEmployeeRepository employeeRepository,
            IOrderRepository orderRepository)
        {
            this.userManager = userManager;
            this.employeeRepository = employeeRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByAppUserId(user.Id);
            var orderList = orderRepository.GetOrderList();

            List<Order> employeeOrderList = new List<Order>();
            if (User.IsInRole("ServiceEmployee")) employeeOrderList = GetServiceEmployeeOrderList(employee, orderList);
            else if (User.IsInRole("DealershipEmployee")) employeeOrderList = GetDealershipEmployeeOrderList(employee, orderList);
            foreach (var order in orderList)
            {
                if (employee.Id == order.DealerEmployeeId)
                    employeeOrderList.Add(order);
            }
            return View(employeeOrderList);
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return View();
        }

        private List<Order> GetDealershipEmployeeOrderList(Employee employee, List<Order> orderList)
        {
            List<Order> employeeOrderList = new List<Order>();
            foreach (var order in orderList)
            {
                if (employee.Id == order.DealerEmployeeId)
                    employeeOrderList.Add(order);
            }
            return employeeOrderList;
        }
        private List<Order> GetServiceEmployeeOrderList(Employee employee, List<Order> orderList)
        {
            List<Order> employeeOrderList = new List<Order>();
            foreach (var order in orderList)
            {
                if (employee.Id == order.ServiceEmployeeId)
                    employeeOrderList.Add(order);
            }
            return employeeOrderList;
        }
    }
}

