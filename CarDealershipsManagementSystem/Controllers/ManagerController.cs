using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Car_Showroom.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Car_Showroom.ViewModels;
using System.Security.Claims;

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

        public IActionResult EmployeeList()
        {
            var employeeList = employeeRepository.GetEmployeeList();
            ViewData["employeeList"] = employeeList;
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
                    AddressCountry = model.Country,
                    AddressCountryCode = model.CountryCode,
                    AddressDistrict = model.District,
                    AddressStreet = model.Street,
                    AddressApartmentNumber = model.ApartmentNumber,
                    AddressPostalCode = model.PostalCode,
                    AddressCity = model.City
                };

                addressRepository.Add(address);
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Login,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = address,
                    PhoneNumber = model.PhoneNumber,
                    Pesel = model.Pesel,
                    BirthDate = model.BirthDate
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
                    var manager = employeeRepository.GetEmployeeById(applicationUser.Id);

                    var employee = new Employee
                    {
                        EmployeeContractType = model.ContractType.ToString(),
                        EmployeeStartDate = model.EmploymentDate,
                        EmployeeJobPosition = model.JobPosition.ToString(),
                        EmployeeSalary = model.Salary,
                        ApplicationUser = user,
                        Dealership = manager.Dealership
                    };
                    employeeRepository.Add(employee);
                    var roleExists = await roleManager.RoleExistsAsync(employee.EmployeeJobPosition);

                    if (!roleExists)
                    {
                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = model.JobPosition.ToString()
                        };
                        await roleManager.CreateAsync(identityRole);
                    }
                    await userManager.AddToRoleAsync(user, employee.EmployeeJobPosition.ToString());
                    return View(model);
                }
                return View(model);
            }
            return View();
        }

        public async Task<IActionResult> CustomerList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeById(applicationUser.Id);
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
            ViewData["customerList"] = customersInDealership;
            return View("Customers/CustomerList");
        }

        public async Task<IActionResult> OrderList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeById(applicationUser.Id);
            var orderList = orderRepository.GetOrderList(manager);
            ViewData["orderList"] = orderList;
            return View("Orders/OrderList");
        }
    }
}