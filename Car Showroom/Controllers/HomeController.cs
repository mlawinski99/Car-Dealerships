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
using Microsoft.AspNetCore.Authorization;
using Car_Showroom.ViewModels;

namespace Car_Showroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository carRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IDetailsRepository detailsRepository;
        public HomeController(ILogger<HomeController> logger, 
            ICarRepository carRepository, 
            UserManager<ApplicationUser> userManager,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IDetailsRepository detailsRepository)
        {
            _logger = logger;
            this.carRepository = carRepository;
            this.userManager = userManager;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.detailsRepository = detailsRepository;
        }

        public IActionResult Index()
        {
            List<Model> modelList =  carRepository.GetModelList();
            return View(modelList);
        }
        public async Task<IActionResult> Details(int id)
        {
            Model model = await carRepository.GetModel(id);
            List<ModelsEngines> modelsEnginesList = carRepository.GetModelsEngines(id);
            List<Engine> engineList = await carRepository.GetEngineList(modelsEnginesList);
            List<ModelsTrims> modelsTrimsList = carRepository.GetModelsTrims(id);
            List<Trim> trimList = await carRepository.GetTrimList(modelsTrimsList);
            var trimOptionTupleList = new List<Tuple<Trim, List<Option>>>();

            foreach (var element in trimList)
            {
                var trimsOptionsList = await carRepository.GetTrimsOptionsList(element.Id);
                var  optionList = await carRepository.GetOptionsList(trimsOptionsList);
                trimOptionTupleList.Add(new Tuple<Trim, List<Option>>(element, optionList));
            }

            ViewData["model"] = model;
            ViewData["engines"] = engineList;
            ViewData["trims"] = trimList;
            ViewData["trimOptionTupleList"] = trimOptionTupleList;
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(CreateCarViewModel model)
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            int customerId = customerRepository.GetCustomerId(applicationUser.Id);

            var details = new Details 
            { 
                ProductionYear = model.ProductionYear,
                Weight = model.Weight
            };
            detailsRepository.Add(details);
            var order = new Order
            {
                CustomerId = customerId,
                Status = 0,
                Price = model.Price,
                Discount = model.Discount,
                PaymentType = model.PaymentType,
                SubmissionDate = DateTime.Now,
                FinalizationDate = DateTime.Now.AddDays(365),
                ShipmentType = model.ShipmentType
            };
            var car = new Car
            {
                ModelId = model.ModelId,
                DealerId = model.DealerId,
                OrderId = order.Id,
                DetailsId = details.Id,
                TrimId = model.TrimId,
                EngineId = model.EngineId
            };
            detailsRepository.Add(details);
            carRepository.Add(car);
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
