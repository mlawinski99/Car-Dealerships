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
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHostingEnvironment hostingEnvironment;
        private readonly IAddressRepository addressRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IDealerRepository dealerRepository;
        private readonly ICarRepository carRepository;
        private readonly IDetailsRepository detailsRepository;
        private readonly IModelRepository modelRepository;
        private readonly ITrimRepository trimRepository;
        private readonly ITrimsOptionsRepository trimsOptionsRepository;
        private readonly IEngineRepository engineRepository;
        private readonly IOptionRepository optionRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        public AdminController(UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IHostingEnvironment hostingEnvironment,
            IAddressRepository addressRepository,
            IEmployeeRepository employeeRepository,
            IDealerRepository dealerRepository,
            ICarRepository carRepository,
            IDetailsRepository detailsRepository,
            IModelRepository modelRepository,
            ITrimRepository trimRepository,
            ITrimsOptionsRepository trimsOptionsRepository,
            IEngineRepository engineRepository,
            IOptionRepository optionRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository
            )
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.hostingEnvironment = hostingEnvironment;
            this.addressRepository = addressRepository;
            this.employeeRepository = employeeRepository;
            this.dealerRepository = dealerRepository;
            this.carRepository = carRepository;
            this.detailsRepository = detailsRepository;
            this.modelRepository = modelRepository;
            this.trimRepository = trimRepository;
            this.trimsOptionsRepository = trimsOptionsRepository;
            this.engineRepository = engineRepository;
            this.optionRepository = optionRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult AddOptionToTrim()
        {
            var trimList = trimRepository.GetTrimList();
            var optionList = optionRepository.GetOptionList();
            ViewBag.trimList = trimList;
            ViewBag.optionList = optionList;
            return View();
        }
        [HttpPost]
        public IActionResult AddOptionToTrim(string trimName, string optionName, string optionDescription)
        {
            var option = new Option
            {
                Description = optionDescription,
                Name = optionName
            };
            optionRepository.Add(option);

            var trimList = trimRepository.GetTrimList();
            var trim = trimList.FirstOrDefault();
            foreach (var t in trimList)
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
        public IActionResult CreateDealer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateDealer(CreateDealerViewModel model)
        {
            //TODO: sprawdź czy dealer o danej nazwie na pewno nie istnieje
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
        public IActionResult CreateEngine()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateEngine(Engine model)
        {
            //TODO: sprawdź czy silnik o danej nazwie na pewno nie istnieje
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
        public IActionResult CreateModel()
        {
            List<Engine> engineList = engineRepository.GetEngineList();
            List<Trim> trimList = trimRepository.GetTrimList();
            ViewData["engineList"] = engineList;
            ViewData["trimList"] = trimList;
            return View();
        }
        [HttpPost]
        public IActionResult CreateModel(CreateModelViewModel viewModel)
        {
            string fileName = null;
            if (viewModel.Image != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "images");
                fileName = Guid.NewGuid().ToString() + "_" + viewModel.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, fileName);
                viewModel.Image.CopyTo(new FileStream(filePath, FileMode.Create));
            }

            var model = new Model
            {
                ImagePath = fileName,
                Name = viewModel.Name,
                Type = viewModel.Type,
            };

            var trim = trimRepository.Get(viewModel.TrimId);
            var engine = trimRepository.Get(viewModel.EngineId);

            List<Engine> engineList = engineRepository.GetEngineList();
            List<Trim> trimList = trimRepository.GetTrimList();
            ViewData["engineList"] = engineList;
            ViewData["trimList"] = trimList;

            return View();
        }

        [HttpGet]
        public IActionResult CreateOption()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateOption(Option model)
        {
            //TODO: sprawdź czy opcja o danej nazwie na pewno nie istnieje
            var option = new Option
            {
                Name = model.Name,
                Description = model.Description
            };
            optionRepository.Add(option);
            return View();
        }

        [HttpGet]
        public IActionResult CreateTrim()
        {
            ViewBag.ShowMessage = false;
            return View();
        }
        [HttpPost]
        public IActionResult CreateTrim(Trim model)
        {
            //TODO: sprawdź czy trim o danej nazwie na pewno nie istnieje
            var trim = new Trim
            {
                Name = model.Name
            };
            trimRepository.Add(trim);
            ViewBag.ShowMessage = true;
            ViewBag.Message = "Trim created successfully";
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

            foreach (var dealer in dealerList)
            {
                List<Employee> managerList = new List<Employee>();
                foreach (var employee in employeeList)
                {
                    if (employee.JobPosition == JobPosition.Manager && employee.DealerId == dealer.Id)
                        managerList.Add(employee);
                }
                dealerManagersList.Add(new Tuple<Dealer, List<Employee>>(dealer, managerList));
            }
            return View(dealerManagersList);
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employeeList = employeeRepository.GetEmployeeList();
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult OrderList()
        {
            var orderList = orderRepository.GetOrderList();
            return View(orderList);
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return View();
        }


    }
}

