using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Car_Showroom.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace CarDealershipsManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator, Manager, Employee")]
    public class EmployeeController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IAddressRepository addressRepository;

        public EmployeeController(
             ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
             IEmployeeRepository employeeRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IAddressRepository addressRepository,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            this.userManager = userManager;
            this.employeeRepository = employeeRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.addressRepository = addressRepository;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CustomerList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeById(applicationUser.Id);
            var orderList = orderRepository.GetOrderList(employee);
            var customerList = customerRepository.GetCustomerList();

            List<Customer> customersInDealership = new List<Customer>();

            foreach (var customer in customerList)
            {
                foreach (var order in orderList)
                {
                    if (order.Customer == customer)
                        customersInDealership.Add(customer);
                }
            }
            customersInDealership = customersInDealership.Distinct().ToList();
            ViewData["customerList"] = customersInDealership;
            return View("Customers/CustomerList");
        }


        public async Task<IActionResult> OrderList()
        {

            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeById(applicationUser.Id);
            var orderList = orderRepository.GetOrderList(employee);
            var orderListInDealership = new List<Order>();
            if (User.IsInRole("DealershipEmployee"))
            {
                foreach (var order in orderList)
                {
                    if (order.DealershipEmployee.Dealership == employee.Dealership)
                        orderListInDealership.Add(order);
                }
            }
            else if (User.IsInRole("ServiceEmployee"))
            {
                foreach (var order in orderList)
                {
                    if (order.DealershipEmployee.Dealership == employee.Dealership)
                        orderListInDealership.Add(order);
                }
            }
            
            ViewData["orderList"] = orderList;
            return View("Orders/OrderList");
        }
    }
}