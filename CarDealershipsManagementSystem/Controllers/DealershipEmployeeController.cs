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
    [Authorize(Roles = "Administrator, Manager, DealershipEmployee")]
    public class DealershipEmployeeController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IAddressRepository addressRepository;

        public DealershipEmployeeController(
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
        public IActionResult OrderList()
        {
            return View();
        }
        [HttpGet]
        public IActionResult ManageOrder()
        {
            return View();
        }
        [HttpPost]
        public IActionResult ManageOrder(DealershipEmployeeManageOrderViewModel viewModel)
        {
            return View();
        }
    }
}