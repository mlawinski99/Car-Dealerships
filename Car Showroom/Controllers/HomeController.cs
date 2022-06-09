using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Car_Showroom.Models;
using Car_Showroom.DataAccess;
using Microsoft.AspNetCore.Identity;

namespace Car_Showroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository carRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        public HomeController(ILogger<HomeController> logger, 
            ICarRepository carRepository, 
            UserManager<ApplicationUser> userManager,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            this.carRepository = carRepository;
            this.userManager = userManager;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
        }

        public IActionResult Index()
        {
            List<Model> modelList =  carRepository.GetModelList();
            return View(modelList);
        }
        public async Task<IActionResult> Details(int Id)
        {
            Model model = await carRepository.GetModel(Id);
            List<ModelsEngines> modelsEngines = carRepository.GetModelsEngines(Id);
            List<Engine> enginesList = await carRepository.GetEngineList(modelsEngines);
            List<ModelsTrims> modelsTrims = carRepository.GetModelsTrims(Id);
            List<Trim> trimsList = await carRepository.GetTrimList(modelsTrims);
            //List<List<Option>> optionsList = new List<List<Option>>();
            var tupleTrimOptionList = new List<(Trim, List<Option>)>();

            foreach (var element in trimsList)
            {
                var trimOption = await carRepository.GetTrimsOptionsList(element.Id);
                var  optionList = await carRepository.GetOptionsList(trimOption);
                tupleTrimOptionList.Add((element, optionList));
              //  optionsList.Add(option);
            }

            ViewData["model"] = model;
            ViewData["enginesList"] = enginesList;
            // ViewData["trimsList"] = trimsList;
            // ViewData["optionsList"] = optionsList;
            ViewData["tupleTrimOptionList"] = tupleTrimOptionList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(int Id, double price, double discount, PaymentType paymentType, ShipmentType shipmentType)
        {
            //  var user = await _userManager.FindByEmailAsync(User.Identity.Name);
            //get user id -> get customer FK -> sign to CustomerId -> delete Car

            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            int customerId = customerRepository.GetCustomerId(applicationUser.Id);

            var order = new Order
            {
                CustomerId = customerId,
                Status = 0,
                Price = price,
                Discount = discount,
                PaymentType = paymentType,
                SubmissionDate = DateTime.Now,
                FinalizationDate = DateTime.Now.AddDays(7),
                ShipmentType = shipmentType
            };
            orderRepository.Add(order);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
