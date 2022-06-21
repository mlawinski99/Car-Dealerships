﻿using System;
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
    public class ManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAddressRepository addressRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDealerRepository dealerRepository;
        private readonly ICarRepository carRepository;
        private readonly IDetailsRepository detailsRepository;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IModelRepository modelRepository;
        private readonly IModelsTrimsRepository modelsTrimsRepository;
        private readonly IModelsEnginesRepository modelsEnginesRepository;
        private readonly ITrimRepository trimRepository;
        private readonly IEngineRepository engineRepository;
        private readonly IOptionRepository optionRepository;
        private readonly ITrimsOptions trimsOptionsRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;

        public ManagementController(UserManager<ApplicationUser> userManager,
            IAddressRepository addressRepository,
             IEmployeeRepository employeeRepository,
             IDealerRepository dealerRepository,
             ICarRepository carRepository,
            IDetailsRepository detailsRepository,
            IHostingEnvironment hostingEnvironment,
            IModelRepository modelRepository,
            IModelsTrimsRepository modelsTrimsRepository,
            IModelsEnginesRepository modelsEnginesRepository,
            ITrimRepository trimRepository,
            IEngineRepository engineRepository,
            IOptionRepository optionRepository,
            ITrimsOptions trimsOptionsRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository
            )
        {
            this.userManager = userManager;
            this.addressRepository = addressRepository;
            this.employeeRepository = employeeRepository;
            this.dealerRepository = dealerRepository;
            this.carRepository = carRepository;
            this.detailsRepository = detailsRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.modelRepository = modelRepository;
            this.modelsTrimsRepository = modelsTrimsRepository;
            this.modelsEnginesRepository = modelsEnginesRepository;
            this.trimRepository = trimRepository;
            this.engineRepository = engineRepository;
            this.optionRepository = optionRepository;
            this.trimsOptionsRepository = trimsOptionsRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employeeList = employeeRepository.GetEmployeeList();
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            var dealerList = dealerRepository.GetDealerList();
            return View(dealerList);
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
                    //int managerId = employeeRepository.GetEmployeeId(applicationUser.Id);
                    var employee = new Employee
                    {
                        ContractType = model.ContractType,
                        EmploymentDate = model.EmploymentDate,
                        JobPosition = model.JobPosition,
                        Salary = model.Salary,
                        ApplicationUserId = user.Id,
                        ManagerId = 0,//managerId,
                        DealerId = model.DealerId
                    };
                    employeeRepository.Add(employee);
                    await userManager.AddToRoleAsync(user, employee.JobPosition.ToString());
                    return View(model);
                }
                return View(model);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateDealer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDealer(CreateDealerViewModel model)
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
            var dealer = new Dealer
            {
                AddressId = address.Id,
                Name = model.Name,
                MaxCarsNumber = model.MaxCarsNumber
            };
            dealerRepository.Add(dealer);
            return View();
        }

        [HttpGet]
        public IActionResult CreateCar()
        {
            var modelList = carRepository.GetModelList();
            var engineList = carRepository.GetEngineList();
            var trimList = carRepository.GetTrimList();
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
                Used = model.Used,
                Crashed = model.Crashed
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
        public async Task<IActionResult> CreateModel()
        {
            List<Engine> engineList = await carRepository.GetEngineList();
            List<Trim> trimList = await carRepository.GetTrimList();
            ViewData["engineList"] = engineList;
            ViewData["trimList"] = trimList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateModel(CreateModelViewModel mod)
        {
            string fileName = null;
            if (mod.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + mod.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                mod.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            var model = new Model
            {
                ImagePath = fileName,
                Name = mod.Name,
                Type = mod.Type,
            };
            modelRepository.Add(model);
            var modelTrim = new ModelsTrims
            {
                ModelId = model.Id,
                TrimId = mod.TrimId
            };
            modelsTrimsRepository.Add(modelTrim);
            var modelEngine = new ModelsEngines
            {
                ModelId = model.Id,
                EngineId = mod.EngineId
            };
            modelsEnginesRepository.Add(modelEngine);

            List<Engine> engineList = await carRepository.GetEngineList();
            List<Trim> trimList = await carRepository.GetTrimList();
            ViewData["engineList"] = engineList;
            ViewData["trimList"] = trimList;

            return View();
        }

        [HttpGet]
        public IActionResult CreateTrim()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateTrim(Trim model)
        {
            var trim = new Trim
            {
                Name = model.Name
            };
            trimRepository.Add(trim);
            return View();
        }

        [HttpGet]
        public IActionResult CreateEngine()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateEngine(Engine model)
        {
            var engine = new Engine
            {
                Type = model.Type,
                Name = model.Name,
                Size = model.Size,
                Power = model.Power,
                Price = model.Price,
                FuelConsumption = model.FuelConsumption,
                EnergyConsumption = model.EnergyConsumption
            };
            engineRepository.Add(engine);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AddOptionToTrim()
        {
            var trimList = await carRepository.GetTrimList();
            return View(trimList);
        }

        [HttpPost]
        public async Task<IActionResult> AddOptionToTrimAsync(string trimName, string optionName, string optionDescription)
        {
            var option = new Option
            {
                Description = optionDescription,
                Name = optionName
            };
            optionRepository.Add(option);

            var trimList = await carRepository.GetTrimList();
            var trim = trimList.FirstOrDefault();
            foreach(var t in trimList)
            {
                if (t.Name == trimName)
                {
                    trim = t;
                    break;
                }
            }

            var trimsOptions = new TrimsOptions
            {
                TrimId = trim.Id,
                OptionId = option.Id
            };
            trimsOptionsRepository.Add(trimsOptions);

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
        public IActionResult DealerList()
        {
            
            List<Tuple<Dealer, List<Employee>>> dealerManagersList = new List<Tuple<Dealer, List<Employee>>>();
            var employeeList = employeeRepository.GetEmployeeList();
            var dealerList = dealerRepository.GetDealerList();
            
            foreach(var dealer in dealerList)
            {
                List<Employee> managerList = new List<Employee>();
                foreach(var employee in employeeList)
                {
                    if (employee.JobPosition == JobPosition.Manager && employee.DealerId == dealer.Id)
                        managerList.Add(employee);
                }
                dealerManagersList.Add(new Tuple<Dealer, List<Employee>>(dealer, managerList));
            }
            return View(dealerManagersList);
        }
        [HttpGet]
        public IActionResult OrderList()
        {
            var orderList = orderRepository.GetOrderList();
            return View(orderList);
        }

        [HttpGet]
        public async Task<IActionResult> ManagerEmployeeList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeById(user.Id);
            var employeeList = employeeRepository.GetEmployeeList();
            List<Employee> managerEmployees = new List<Employee>();
            foreach(var employee in employeeList)
            {
                if (manager.DealerId == employee.DealerId)
                    managerEmployees.Add(employee);
            }
            return View(managerEmployees);
        }

        [HttpGet]
        public async Task<IActionResult> ManagerOrderList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeById(user.Id);
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
        public async Task<IActionResult> EmployeeOrderList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeById(user.Id);
            var orderList = orderRepository.GetOrderList();
            List<Order> employeeOrderList = new List<Order>();
            foreach (var order in orderList)
            {
                if (employee.Id == order.DealerEmployeeId)
                    employeeOrderList.Add(order);
            }
            return View(employeeOrderList);
        }
        [HttpGet]
        public async Task<IActionResult> ServiceOrderList()
        {
            var user = await userManager.GetUserAsync(HttpContext.User);
            var employee = employeeRepository.GetEmployeeById(user.Id);
            var orderList = orderRepository.GetOrderList();
            List<Order> employeeOrderList = new List<Order>();
            foreach (var order in orderList)
            {
                if (employee.Id == order.ServiceEmployeeId)
                    employeeOrderList.Add(order);
            }
            return View(employeeOrderList);
        }

    }
}

