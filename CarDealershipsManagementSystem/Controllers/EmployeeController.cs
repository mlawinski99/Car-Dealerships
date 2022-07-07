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
    [Authorize(Roles = "Administrator, Manager, DealershipEmployee, ServiceEmployee")]
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
        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);

            if (User.IsInRole("DealershipEmployee"))
                ViewBag.orderList = orderRepository.GetOrdersForDealershipEmployee(employee);
            else if (User.IsInRole("ServiceEmployee"))
                ViewBag.orderList = orderRepository.GetOrdersForServiceEmployee(employee);
            return View();
        }

        [HttpGet]
        public IActionResult NewOrder()
        {

            return View();
        }
        [HttpPost]
        public IActionResult NewOrder(CreateOrderViewModel viewModel)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangeOrder()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            orderRepository.GetOrderList();

            return View();
        }

    }
}