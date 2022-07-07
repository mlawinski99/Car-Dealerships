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
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly ICarRepository carRepository;
        private readonly IDealershipRepository dealershipRepository;
        private readonly IEngineRepository engineRepository;
        private readonly IEquipmentRepository equipmentRepository;
        public HomeController(
            ILogger<HomeController> logger,
            IModelRepository modelRepository,
            UserManager<ApplicationUser> userManager,
            IOrderRepository orderRepository,
            ICarRepository carRepository,
            IDealershipRepository dealershipRepository,
            IEngineRepository engineRepository,
            IEquipmentRepository equipmentRepository
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
        }

        public IActionResult Index()
        {
            ViewBag.modelList = modelRepository.GetModelList();
            return View();
        }

        public IActionResult Details(int id)
        {

            Model? model = modelRepository.GetModelById(id);
            /*_context.Models
            .Where(m => m.ModelId == id)
            .Include(m => m.Engines)
            .Include(m => m.Equipments)
            .ThenInclude(e => e.Options)
            .FirstOrDefault();*/

            List<Engine> engines = model.Engines.ToList();

            List<Equipment> equipments = model.Equipments.ToList();

            /*    
                List<Tuple<Equipment, List<Option>>> equipmentOptionTupleList = new List<Tuple<Equipment, List<Option>>>();

                foreach (var eq in equipments)
                {
                    Equipment? equipment = _context.Equipments
                        .Where(e => e.EquipmentId == eq.EquipmentId)
                        .Include(e => e.Options)
                        .FirstOrDefault();

                    var optionList = equipment.Options.ToList();
                    equipmentOptionTupleList.Add(new Tuple<Equipment, List<Option>>(eq, optionList));
                }
            */
            ViewBag.chosenModel = model;
            ViewBag.engineList = engines;
            ViewBag.equipmentList = equipments;

            //  ViewBag.equipmentOptionTupleList = equipmentOptionTupleList;

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
        public async Task<IActionResult> CreateOrder(CreateCarViewModel model)
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            Customer customer = customerRepository.GetCustomerByAppUserId(applicationUser.Id);
            
            var order = new Order
            {
                Customer = customer,
                OrderStatus = model.OrderStatus.ToString(),
                OrderPrice = model.OrderPrice,
                OrderDiscount = model.OrderDiscount,
                OrderPaymentType = model.OrderPaymentType,
                OrderSubmissionDate = DateTime.Now,
                OrderFinalizationDate = DateTime.Now.AddDays(100),
                OrderShipmentType = model.OrderShipmentType,
                Dealership = dealershipRepository.GetDealershipById(model.DealershipId)
            };
            
            var car = new Car
            {
                Dealership = dealershipRepository.GetDealershipById(model.DealershipId),
                Engine = engineRepository.GetEngineById(model.EngineId),
                Equipment = equipmentRepository.GetEquipmentById(model.EquipmentId),
                Model = modelRepository.GetModelById(model.ModelId),
                CarProductionYear = model.CarProductionYear,
                CarWeight = model.CarWeight,
                CarUsed = model.CarUsed,
                CarCrashed = model.CarCrashed
            };
            car.Order = order;
            carRepository.Add(car);
            orderRepository.Add(order);
            return View();
        }
    }
}