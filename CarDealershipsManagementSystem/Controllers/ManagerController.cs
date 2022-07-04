using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.ViewModels;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System;

namespace CarDealershipsManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator, Manager")]
    public class ManagerController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IAddressRepository addressRepository;

        public ManagerController(
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

        public async Task<IActionResult> EmployeeList()
        {
            ApplicationUser managerApplicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(managerApplicationUser.Id);
            var employeeList = employeeRepository.GetEmployeeListForManager(manager);

            ViewBag.employeeList = employeeList;
            return View("Employees/EmployeeList");
        }
        [HttpGet]
        public IActionResult AddNewEmployee()
        {
            
            return View("Employees/AddNewEmployee");
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(CreateEmployeeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    AddressCountry = model.AddressCountry,
                    AddressCountryCode = model.AddressCountryCode,
                    AddressDistrict = model.AddressDistrict,
                    AddressStreet = model.AddressStreet,
                    AddressApartmentNumber = model.AddressApartmentNumber,
                    AddressPostalCode = model.AddressPostalCode,
                    AddressCity = model.AddressCity
                };

                addressRepository.Add(address);
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = address,
                    PhoneNumber = model.PhoneNumber,
                    Pesel = model.Pesel,
                    BirthDate = model.BirthDate
                };
                string Pass = string.Concat(model.FirstName.AsSpan(0, 3), model.LastName.AsSpan(0, 3),model.Pesel.AsSpan(0,3), "!");
                var result = await userManager.CreateAsync(user, Pass);
                if (result.Succeeded)
                {
                    ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
                    var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);

                    var employee = new Employee
                    {
                        EmployeeContractType = model.EmployeeContractType,
                        EmployeeStartDate = model.EmployeeStartDate,
                        EmployeeFinishDate = model.EmployeeFinishDate,
                        EmployeeJobPosition = model.EmployeeJobPosition,
                        EmployeeSalary = model.EmployeeSalary,
                        ApplicationUser = user,
                        Dealership = manager.Dealership
                    };
                    employeeRepository.Add(employee);
                    var roleExists = await roleManager.RoleExistsAsync(employee.EmployeeJobPosition);

                    if (!roleExists)
                    {
                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = model.EmployeeJobPosition
                        };
                        await roleManager.CreateAsync(identityRole);
                    }
                    await userManager.AddToRoleAsync(user, employee.EmployeeJobPosition);
                    ViewBag.message = "Employee " + model.Email + " added successfully with password " + Pass;
                    return View("Employees/AddNewEmployee");
                }
                ViewBag.message = "Something went wrong, employee not added";
                return View("Employees/AddNewEmployee");
            }
            ViewBag.message = "Something went wrong, employee not added";
            return View("Employees/AddNewEmployee");
        }

        public async Task<IActionResult> CustomerList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            var orderList = orderRepository.GetOrderList(manager);
            var customerList = customerRepository.GetCustomerList();

            List<Customer> customersInDealership = new List<Customer>();

            foreach(var customer in customerList)
            {
                foreach(var order in orderList)
                {
                    if (order.Customer == customer)
                        customersInDealership.Add(customer);
                }
            }
            customersInDealership = customersInDealership.Distinct().ToList();
            ViewBag.customerList = customersInDealership;
            return View("Customers/CustomerList");
        }

        public async Task<IActionResult> OrderList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            var orderList = orderRepository.GetOrderList(manager);
            var orderListInDealership = new List<Order>();
                foreach (var order in orderList)
                {
                    if (order.DealershipEmployee.Dealership == manager.Dealership)
                        orderListInDealership.Add(order);
                }
            ViewBag.orderList = orderListInDealership;
            return View("Orders/OrderList");
        }
    }
}