using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CarDealershipsManagementSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelRepository modelRepository;

        public HomeController(
            ILogger<HomeController> logger,
            IModelRepository modelRepository
            )
        {
            _logger = logger;
            this.modelRepository = modelRepository;
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
    }
}