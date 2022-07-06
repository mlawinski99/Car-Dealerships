using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using CarDealershipsManagementSystem.ViewModels;

namespace CarDealershipsManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator, Manager, ServiceEmployee")]
    public class ServiceEmployeeController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IAddressRepository addressRepository;

        public ServiceEmployeeController(
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
        public async Task<IActionResult> OrderList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            var orderList = orderRepository.GetOrderList(employee);
            var orderListInDealership = new List<Order>();
            if (User.IsInRole("ServiceEmployee"))
            {
                foreach (var order in orderList)
                {
                    if (order.ServiceEmployee.Dealership == employee.Dealership)
                        orderListInDealership.Add(order);
                }
            }
            ViewData["orderList"] = orderList;
            return View("Orders/OrderList");
        }
        [HttpGet]
        public IActionResult ManageOrder(int id)
        {
            var order = orderRepository.GetOrderById(id);
            return View(order);
        }
        [HttpPost]
        public IActionResult ManageOrder(ServiceEmployeeManageOrderViewModel viewModel)
        {
            return View();
        }
    }
}