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
        private readonly IDealershipRepository dealershipRepository;

        public EmployeeController(
             ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
             IEmployeeRepository employeeRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IAddressRepository addressRepository,
            RoleManager<IdentityRole> roleManager,
            IDealershipRepository dealershipRepository
            )
        {
            _logger = logger;
            this.userManager = userManager;
            this.employeeRepository = employeeRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.addressRepository = addressRepository;
            this.roleManager = roleManager;
            this.dealershipRepository = dealershipRepository;
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

        public async Task<IActionResult> AcceptOrder(int id)
        {
            //znajdź pracownika salonu, który zaakceptował zamówienie
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            //znajdź zaakceptowane zamówienie
            Order order = orderRepository.GetOrderById(id);
            //dodaj to zamówienie do listy zamówień tego pracownika salonu
            employee.DealershipOrders.Add(order);
            //dodaj tego pracownika salonu jako pracownika zajmującego się zamówieniem
            order.DealershipEmployee = employee;
            //dodaj salon do zamówienia
            order.Dealership = employee.Dealership;
            //znajdź pierwszego lepszego pracownika tego samego serwisu i dodaj go jako zajmującego się zamówieniem
            Employee serviceEmployee = dealershipRepository.GetRandomServiceEmployeeOfDealership(employee.Dealership.DealershipId);
            serviceEmployee.ServiceOrders.Add(order);
            order.ServiceEmployee = serviceEmployee;
            order.OrderStatus = "Zaakceptowane";

            orderRepository.Update(order);
            employeeRepository.Update(employee);
            employeeRepository.Update(serviceEmployee);

            ViewBag.orderList = orderRepository.GetOrdersForDealershipEmployee(employee);
            return View("OrderList");
        }

        public async Task<IActionResult> SendOrderToService(int id)
        {
            //znajdź pracownika salonu, który kliknął żeby wysłać do serwisu
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            //znajdź wysłane zamówienie
            Order order = orderRepository.GetOrderById(id);
            //zmień status na WSerwisie
            order.OrderStatus = "WSerwisie";

            orderRepository.Update(order);
            ViewBag.orderList = orderRepository.GetOrdersForDealershipEmployee(employee);
            return View("OrderList");
        }

        public async Task<IActionResult> SendOrderToClient(int id)
        {
            //znajdź pracownika salonu, który kliknął żeby wysłać do klienta zamówienie
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            //znajdź wysłane zamówienie
            Order order = orderRepository.GetOrderById(id);
            order.OrderStatus = "Wyslane";

            orderRepository.Update(order);
            ViewBag.orderList = orderRepository.GetOrdersForDealershipEmployee(employee);
            return View("OrderList");
        }

        public async Task<IActionResult> SetOrderReady(int id)
        {
            //znajdź pracownika serwisu, który skończył pracę nad zamówieniem
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            //znajdź skończone zamówienie
            Order order = orderRepository.GetOrderById(id);

            order.OrderStatus = "Gotowe";

            orderRepository.Update(order);
            ViewBag.orderList = orderRepository.GetOrdersForServiceEmployee(employee);
            return View("OrderList");
        }



    }
}