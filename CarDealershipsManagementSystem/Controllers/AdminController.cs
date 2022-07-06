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

        [HttpGet]
        public IActionResult AddOptionsToEquipment()
        {
            ViewBag.equipmentList = equipmentRepository.GetEquipmentList();
            ViewBag.optionList = optionRepository.GetOptionList();
            return View("Models/AddOptionsToEquipment");
        }
        [HttpPost]
        public IActionResult AddOptionsToEquipment(AddOptionsToEquipmentViewModel viewModel)
        {
            Equipment equipment = equipmentRepository.GetEquipmentById(int.Parse(viewModel.EquipmentId));
            var optionList = equipment.Options;
            foreach (var item in viewModel.OptionIdList)
            {
                Option option = optionRepository.GetOptionById(int.Parse(item));
                if (!optionList.Contains(option))
                    optionList.Add(option);
            }
            equipment.Options = optionList;
            equipmentRepository.Update(equipment);

            ViewBag.equipmentList = equipmentRepository.GetEquipmentList();
            return View("Models/EquipmentList");
        }
        [HttpGet]
        public IActionResult AddEnginesToModel()
        {
            ViewBag.engineList = engineRepository.GetEngineList();
            ViewBag.modelList = modelRepository.GetModelList();
            return View("Models/AddEnginesToModel");
        }
        [HttpPost]
        public IActionResult AddEnginesToModel(AddEnginesToModelViewModel viewModel)
        {
            Model model = modelRepository.GetModelById(int.Parse(viewModel.ModelId));
            var engineList = model.Engines;
            foreach (var item in viewModel.EngineIdList)
            {
                Engine engine = engineRepository.GetEngineById(int.Parse(item));
                if (!engineList.Contains(engine))
                    engineList.Add(engine);
            }
            model.Engines = engineList;
            modelRepository.Update(model);

            ViewBag.modelList = modelRepository.GetModelList();
            return View("Models/ModelList");
        }
        [HttpGet]
        public IActionResult AddEquipmentsToModel()
        {
            ViewBag.equipmentList = equipmentRepository.GetEquipmentList();
            ViewBag.modelList = modelRepository.GetModelList();
            return View("Models/AddEquipmentsToModel");
        }
        [HttpPost]
        public IActionResult AddEquipmentsToModel(AddEquipmentsToModelViewModel viewModel)
        {
            Model model = modelRepository.GetModelById(int.Parse(viewModel.ModelId));
            var equipmentList = model.Equipments;
            foreach (var item in viewModel.EquipmentIdList)
            {
                Equipment equipment = equipmentRepository.GetEquipmentById(int.Parse(item));
                if (!equipmentList.Contains(equipment))
                    equipmentList.Add(equipment);
            }
            model.Equipments = equipmentList;
            modelRepository.Update(model);

            ViewBag.modelList = modelRepository.GetModelList();
            return View("Models/ModelList");
        }

        public IActionResult CustomerList()
        {
            var customerList = customerRepository.GetCustomerList();
            ViewBag.customerList = customerList;
            return View("Customers/CustomerList");
        }
        public IActionResult OrderList()
        {
            var orderList = orderRepository.GetOrderList();
            ViewBag.orderList = orderList;
            return View("Orders/OrderList");
        }

        #region Zrobione
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult EngineList()
        {
            ViewBag.engineList = engineRepository.GetEngineList();
            return View("Models/EngineList");
        }
        [HttpGet]
        public IActionResult AddNewEngine()
        {
            return View("Models/AddNewEngine");
        }
        [HttpPost]
        public IActionResult AddNewEngine(Engine engine)
        {
            engineRepository.Add(engine);
            ViewBag.message = $"Silnik {engine.EngineName} dodany poprawnie";
            ViewBag.engineList = engineRepository.GetEngineList();
            return View("Models/EngineList");
        }
        [HttpGet]
        public IActionResult OptionList()
        {
            ViewBag.optionList = optionRepository.GetOptionList();
            return View("Models/OptionList");
        }
        [HttpGet]
        public IActionResult AddNewOption()
        {
            return View("Models/AddNewOption");
        }
        [HttpPost]
        public IActionResult AddNewOption(Option option)
        {
            optionRepository.Add(option);
            ViewBag.message = $"Opcja {option.OptionName} dodana poprawnie";
            ViewBag.optionList = optionRepository.GetOptionList();
            return View("Models/OptionList");
        }
        [HttpGet]
        public IActionResult EquipmentList()
        {
            ViewBag.equipmentList = equipmentRepository.GetEquipmentList();
            return View("Models/EquipmentList");
        }
        [HttpGet]
        public IActionResult AddNewEquipment()
        {
            ViewBag.optionList = optionRepository.GetOptionList();
            return View("Models/AddNewEquipment");
        }
        [HttpPost]
        public IActionResult AddNewEquipment(CreateEquipmentViewModel equipmentViewModel)
        {
            var OptionList = new List<Option>();
            foreach (var item in equipmentViewModel.OptionIdList)
            {
                OptionList.Add(optionRepository.GetOptionById(int.Parse(item)));
            }
            Equipment equipment = new Equipment
            {
                EquipmentName = equipmentViewModel.EquipmentName,
                EquipmentPrice = equipmentViewModel.EquipmentPrice,
                Options = OptionList
            };
            equipmentRepository.Add(equipment);
            ViewBag.message = $"Wersja wyposazeniowa {equipment.EquipmentName} dodana poprawnie.";
            ViewBag.equipmentList = equipmentRepository.GetEquipmentList();
            return View("Models/EquipmentList");
        }
        [HttpGet]
        public IActionResult ModelList()
        {
            ViewBag.modelList = modelRepository.GetModelList();
            return View("Models/ModelList");
        }
        [HttpGet]
        public IActionResult AddNewModel()
        {
            ViewBag.engineList = engineRepository.GetEngineList();
            ViewBag.equipmentList = equipmentRepository.GetEquipmentList();
            return View("Models/AddNewModel");
        }
        [HttpPost]
        public IActionResult AddNewModel(CreateModelViewModel mod)
        {
            var EngineList = new List<Engine>();
            foreach (var item in mod.EngineIdList)
            {
                EngineList.Add(engineRepository.GetEngineById(int.Parse(item)));
            }
            var EquipmentList = new List<Equipment>();
            foreach (var item in mod.EquipmentIdList)
            {
                EquipmentList.Add(equipmentRepository.GetEquipmentById(int.Parse(item)));
            }

            var model = new Model
            {
                ModelImagePath = $"/images/{mod.ModelName}.png",
                ModelName = mod.ModelName,
                ModelType = mod.ModelType,
                ModelPrice = mod.ModelPrice,
                Engines = EngineList,
                Equipments = EquipmentList
            };
            modelRepository.Add(model);

            ViewBag.message = $"Model {mod.ModelName} dodany pomyślnie";
            ViewBag.modelList = modelRepository.GetModelList();
            return View("Models/ModelList");
        }
        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employeeList = employeeRepository.GetEmployeeList().Where(e => e.Dealership != null);
            ViewBag.employeeList = employeeList;
            return View("Employees/EmployeeList");
        }
        [HttpGet]
        public IActionResult AddNewEmployee()
        {
            var dealershipList = dealershipRepository.GetDealershipList();
            ViewBag.dealershipList = dealershipList;
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
                string Pass = string.Concat(model.FirstName.AsSpan(0, 3), model.LastName.AsSpan(0, 3), model.Pesel.AsSpan(0, 3), "!");
                var result = await userManager.CreateAsync(user, Pass);
                if (result.Succeeded)
                {
                    int dealershipId = int.Parse(model.DealershipId);
                    Dealership dealership = dealershipRepository.GetDealershipById(dealershipId);
                    var employee = new Employee
                    {
                        EmployeeContractType = model.EmployeeContractType,
                        EmployeeStartDate = model.EmployeeStartDate,
                        EmployeeFinishDate = model.EmployeeFinishDate,
                        EmployeeJobPosition = model.EmployeeJobPosition,
                        EmployeeSalary = model.EmployeeSalary,
                        ApplicationUser = user,
                        Dealership = dealership
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
                    ViewBag.message = "Manager " + model.Email + " dodany pomyślnie";

                    var employeeList = employeeRepository.GetEmployeeList();
                    ViewBag.employeeList = employeeList;
                    return View("Employees/EmployeeList");
                }
                ViewBag.message = "Something went wrong, Manager not added";
                return View("Employees/AddNewEmployee");
            }
            ViewBag.message = "Something went wrong, Manager not added";
            return View("Employees/AddNewEmployee");
        }
        [HttpGet]
        public IActionResult DealershipList()
        {
            var dealershipList = dealershipRepository.GetDealershipList();
            ViewBag.dealershipList = dealershipList;
            return View("Dealerships/DealershipList");
        }
        [HttpGet]
        public IActionResult AddNewDealership()
        {

            return View("Dealerships/AddNewDealership");
        }
        [HttpPost]
        public IActionResult AddNewDealership(CreateDealershipViewModel model)
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
            var dealer = new Dealership
            {
                Address = address,
                DealershipName = model.Name,
                DealershipMaxCarsNumber = model.MaxCarsNumber
            };
            dealershipRepository.Add(dealer); 
            ViewBag.message = "Salon " + model.Name + " dodany poprawnie.";

            var dealershipList = dealershipRepository.GetDealershipList();
            ViewBag.dealershipList = dealershipList;
            return View("Dealerships/DealershipList");
        }
        #endregion
    }
}