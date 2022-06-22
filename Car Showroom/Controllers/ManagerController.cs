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
    public class ManagerController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IAddressRepository addressRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICarRepository carRepository;
        private readonly IDetailsRepository detailsRepository;
        private readonly IModelRepository modelRepository;
        private readonly ITrimRepository trimRepository;
        private readonly IEngineRepository engineRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        public ManagerController(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IHostingEnvironment hostingEnvironment,
            IAddressRepository addressRepository,
            IEmployeeRepository employeeRepository,
            ICarRepository carRepository,
            IDetailsRepository detailsRepository,
            IModelRepository modelRepository,
            ITrimRepository trimRepository,
            IEngineRepository engineRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.hostingEnvironment = hostingEnvironment;
            this.addressRepository = addressRepository;
            this.employeeRepository = employeeRepository;
            this.carRepository = carRepository;
            this.detailsRepository = detailsRepository;
            this.modelRepository = modelRepository;
            this.trimRepository = trimRepository;
            this.engineRepository = engineRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }


        [HttpGet]
        public IActionResult CreateCar()
        {
            var modelList = modelRepository.GetModelList();
            var engineList = engineRepository.GetEngineList();
            var trimList = trimRepository.GetTrimList();
            ViewData["modelList"] = modelList;
            ViewData["engineList"] = engineList;
            ViewData["trimList"] = trimList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateCar(CreateCarViewModel model)
        {
            var details = new Details
            {
                ProductionYear = model.ProductionYear,
                Weight = model.Weight,
                //Used = model.Used,
                //Crashed = model.Crashed
            };
            detailsRepository.Add(details);
            var Car = new Car
            {
                DetailsId = details.Id,
                DealerId = model.DealerId,
                OrderId = null,
                ModelId = model.ModelId,
                TrimId = model.TrimId,
                EngineId = model.EngineId
            };
            carRepository.Add(Car);
            return View();
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Country = model.Country,
                    CountryCode = model.CountryCode,
                    District = model.District,
                    Street = model.Street,
                    ApartmentNumber = model.ApartmentNumber,
                    PostalCode = model.PostalCode,
                    City = model.City
                };
                addressRepository.Add(address);

                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Login,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AddressId = address.Id,
                    PhoneNumber = model.PhoneNumber,
                    Pesel = model.Pesel,
                    BirthDate = model.BirthDate
                };
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
                    var manager = employeeRepository.GetEmployeeByAppUserId(applicationUser.Id);
                    int managerId = 0;
                    int dealerId = 1;
                    if (manager != null)
                    {
                        managerId = manager.Id;
                        dealerId = manager.DealerId;
                    }

                    var employee = new Employee
                    {
                        ContractType = model.ContractType,
                        EmploymentDate = model.EmploymentDate,
                        JobPosition = model.JobPosition,
                        Salary = model.Salary,
                        ApplicationUserId = user.Id,
                        ManagerId = managerId,
                        DealerId = dealerId
                    };
                    employeeRepository.Add(employee);

                    var roleExists = await roleManager.RoleExistsAsync(model.JobPosition.ToString());
                    if (!roleExists)
                    {
                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = model.JobPosition.ToString()
                        };
                        await roleManager.CreateAsync(identityRole);
                    }
                    await userManager.AddToRoleAsync(user, employee.JobPosition.ToString());

                    return View(model);
                }
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CustomerList()
        {
            var customerList = customerRepository.GetCustomerList();
            /*  List<Tuple<Customer, Address>> customerAddressList = new List<Tuple < Customer, Address>>();

              foreach(var customer in customerList)
              {
                  customer.
                  var customerAddress = customer.ApplicationUser.Address;
                  customerAddressList.Add(new Tuple<Customer, Address>(customer, customerAddress));
              }*/
            return View(customerList);
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByAppUserId(user.Id);
            var employeeList = employeeRepository.GetEmployeeList();
            List<Employee> managerEmployees = new List<Employee>();
            foreach (var employee in employeeList)
            {
                if (manager.DealerId == employee.DealerId)
                    managerEmployees.Add(employee);
            }
            return View(managerEmployees);
        }

        [HttpGet]
        public async Task<IActionResult> OrderList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByAppUserId(user.Id);
            var orderList = orderRepository.GetOrderList();
            List<Order> managerOrderList = new List<Order>();
            foreach (var order in orderList)
            {
                if (manager.DealerId == order.DealerEmployee.DealerId)
                    managerOrderList.Add(order);
            }
            return View(managerOrderList);
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return View();
        }
    }
}

