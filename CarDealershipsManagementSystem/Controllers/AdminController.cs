using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Car_Showroom.DataAccess;
using Microsoft.AspNetCore.Authorization;
using Car_Showroom.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace CarDealershipsManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IModelRepository modelRepository;
        private readonly IAddressRepository addressRepository;
        private readonly IDealershipRepository dealershipRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICarRepository carRepository;
        private readonly IEngineRepository engineRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IOptionRepository optionRepository;

        public AdminController(
            ILogger<HomeController> logger,
            IModelRepository modelRepository,
            IAddressRepository addressRepository,
            IDealershipRepository dealershipRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            ICarRepository carRepository,
            IEngineRepository engineRepository,
            IEquipmentRepository equipmentRepository,
            IWebHostEnvironment hostingEnvironment,
            IEmployeeRepository employeeRepository,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptionRepository optionRepository
            )
        {
            _logger = logger;
            this.modelRepository = modelRepository;
            this.addressRepository = addressRepository;
            this.dealershipRepository = dealershipRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.carRepository = carRepository;
            this.engineRepository = engineRepository;
            this.equipmentRepository = equipmentRepository;
            this.hostingEnvironment = hostingEnvironment;
            this.employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.optionRepository = optionRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelList()
        {
            var modelList = modelRepository.GetModelList();
            ViewData["modelList"] = modelList;
            return View("Models/ModelList");
        }

        [HttpGet]
        public IActionResult AddNewModel()
        {
            List<Engine> engineList =  engineRepository.GetEngineList();
            List<Equipment> equipmentList =  equipmentRepository.GetEquipmentList();
            ViewData["engineList"] = engineList;
            ViewData["equipmentList"] = equipmentList;
            return View("Models/AddNewModel");
        }
        [HttpPost]
        public IActionResult AddNewModel(CreateModelViewModel mod)
        {
            string fileName = null;
            if (mod.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + Path.GetFileName(mod.Image.FileName);
                string filePath = Path.Combine(uploadsFolder, fileName);
                mod.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }
            var model = new Model
            {
                ModelImagePath = fileName,
                ModelName = mod.Name,
                ModelType = mod.Type.ToString(),
            };
            modelRepository.Add(model);


            return View("Models/AddNewModel");
        }
        [HttpGet]
        public IActionResult AddNewEngine()
        {
            return View("Models/AddNewEngine");
        }
        [HttpPost]
        public IActionResult AddNewEngine(Engine model)
        {
            var engine = new Engine
            {
                EngineType = model.EngineType,
                EngineName = model.EngineName,
                EnginePower = model.EnginePower,
                EnginePrice = model.EnginePrice,
                EngineDisplacement = model.EngineDisplacement,
                EnigneFuelConsumption = model.EnigneFuelConsumption,
                EnginePowerConsumption = model.EnginePowerConsumption,
            };
            engineRepository.Add(engine);
            return View("Models/AddNewEngine");
        }
        [HttpGet]
        public IActionResult AddNewOption()
        {
            return View("Models/AddNewOption");
        }
        [HttpPost]
        public IActionResult AddNewOption(Option model)
        {
            var option = new Option
            {
                OptionName = model.OptionDescription,
                OptionDescription = model.OptionDescription,
                OptionPrice = model.OptionPrice
            };
            optionRepository.Add(option);
            return View("Models/AddNewOption");
        }
        [HttpGet]
        public IActionResult AddOptionToEquipment()
        {
            var equipmentList = equipmentRepository.GetEquipmentList();
            var optionList = optionRepository.GetOptionList();
            ViewData["equipmentList"] = equipmentList;
            ViewData["optionList"] = optionList;
            return View("Models/AddNewOption");
        }
        [HttpGet]
        public IActionResult AddOptionToEquipment(Option option, Equipment equipment)
        {
            equipment.Options.Add(option);
            return View("Models/AddNewOption");
        }
        [HttpGet]
        public IActionResult AddNewEquipment()
        {
            return View("Models/AddNewEquipment");
        }
        [HttpPost]
        public IActionResult AddNewEquipment(Equipment model)
        {
            var equipment = new Equipment
            {
                EquipmentName = model.EquipmentName,
                EquipmentPrice = model.EquipmentPrice
            };
            equipmentRepository.Add(equipment);
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
            var dealershipList = dealershipRepository.GetDealershipList();
            ViewData["dealershipList"] = dealershipList;
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
                    var employee = new Employee
                    {
                        EmployeeContractType = model.ContractType.ToString(),
                        EmployeeStartDate = model.EmploymentDate,
                        EmployeeJobPosition = model.JobPosition.ToString(),
                        EmployeeSalary = model.Salary,
                        ApplicationUser = user,
                        Dealership = model.Dealership
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

        public IActionResult DealershipList()
        {
            var dealershipList = dealershipRepository.GetDealershipList();
            ViewData["dealershipList"] = dealershipList;
            return View("Dealerships/DealershipList");
        }

        [HttpGet]
        public IActionResult AddNewDealership()
        {
            return View("Dealerships/AddNewDealership");
        }
        [HttpPost]
        public IActionResult AddNewDealership(CreateDealerViewModel model)
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
            var dealer = new Dealership
            {
                Address = address,
                DealershipName = model.Name,
                DealershipMaxCarsNumber = model.MaxCarsNumber
            };
            dealershipRepository.Add(dealer);
            return View();
        }
        public IActionResult CustomerList()
        {
            var customerList = customerRepository.GetCustomerList();
            ViewData["customerList"] = customerList;
            return View("Customers/CustomerList");
        }
        public IActionResult OrderList()
        {
            var orderList = orderRepository.GetOrderList();
            ViewData["orderList"] = orderList;
            return View("Orders/OrderList");
        }
    }
}