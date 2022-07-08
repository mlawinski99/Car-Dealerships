using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CarDealershipsManagementSystem.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CarDealershipsManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IModelRepository modelRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICarRepository carRepository;
        private readonly IDealershipRepository dealershipRepository;
        private readonly IEngineRepository engineRepository;
        private readonly IEquipmentRepository equipmentRepository;
        private readonly IAddressRepository addressRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOptionRepository optionRepository;
        public HomeController(
            ILogger<HomeController> logger,
            IModelRepository modelRepository,
            UserManager<ApplicationUser> userManager,
            IOrderRepository orderRepository,
            ICarRepository carRepository,
            IDealershipRepository dealershipRepository,
            IEngineRepository engineRepository,
            IEquipmentRepository equipmentRepository,
            IAddressRepository addressRepository,
            ICustomerRepository customerRepository,
            IOptionRepository optionRepository
            )
        {
            _logger = logger;
            this.modelRepository = modelRepository;
            this.userManager = userManager;
            this.orderRepository = orderRepository;
            this.carRepository = carRepository;
            this.dealershipRepository = dealershipRepository;
            this.engineRepository = engineRepository;
            this.equipmentRepository = equipmentRepository;
            this.addressRepository = addressRepository;
            this.customerRepository = customerRepository;
            this.optionRepository = optionRepository;
        }

        public IActionResult Index()
        {
            ViewBag.modelList = modelRepository.GetModelList();
            return View();
        }

        public async Task<IActionResult> Details(int id)
        {

            Model? model = modelRepository.GetModelById(id);
            ViewBag.chosenModel = model;
            ViewBag.engineList = model.Engines.ToList();
            ViewBag.equipmentList = model.Equipments.ToList();
            List<Option> optionList = optionRepository.GetOptionList();
            List<Option> optionListOne = new List<Option>();
            List<Option> optionListTwo = new List<Option>();
            List<Option> optionListThree = new List<Option>();
            for(int i = 0; i < optionList.Count / 3; i++)
            {
                optionListOne.Add(optionList[i]);
            }
            for(int i = optionList.Count / 3; i < optionList.Count / 3 * 2; i++)
            {
                optionListTwo.Add(optionList[i]);
            }
            for(int i = optionList.Count / 3 * 2; i < optionList.Count - (optionList.Count / 3 * 2); i++)
            {
                optionListThree.Add(optionList[i]);
            }

            ViewBag.optionListOne = optionListOne;
            ViewBag.optionListTwo = optionListTwo;
            ViewBag.optionListThree = optionListThree;

            ViewBag.applicationUser = await userManager.GetUserAsync(HttpContext.User);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderViewModel model)
        {
            int modelId = int.Parse(model.ModelId);
            int engineId = int.Parse(model.EngineId);
            int equipmentId = int.Parse(model.EquipmentId);
            int price = int.Parse(model.OrderPrice);

            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            Customer customer = customerRepository.GetCustomerByApplicationUserId(applicationUser.Id);
            
            var order = new Order
            {
                Customer = customer,
                ServiceEmployee = null,
                DealershipEmployee = null,
                Dealership = null,
                OrderStatus = OrderStatuses.Nowe.ToString(),
                OrderPrice = price,
                OrderDiscount = 0,
                OrderPaymentType = model.OrderPaymentType,
                OrderSubmissionDate = DateTime.Now,
                OrderFinalizationDate = null,
                OrderShipmentType = model.OrderShipmentType
            };
            orderRepository.Add(order);

            var car = new Car
            {
                Dealership = null,
                Engine = engineRepository.GetEngineById(engineId),
                Equipment = equipmentRepository.GetEquipmentById(equipmentId),
                Model = modelRepository.GetModelById(modelId),
                Order = order
            };
            carRepository.Add(car);

            order.Cars.Add(car);

            orderRepository.Update(order);

            ViewBag.message = "Zamowienie zlozone pomyslnie";
            ViewBag.modelList = modelRepository.GetModelList();
            return View("Index");
        }
    }
}