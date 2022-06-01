using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Car_Showroom.Models;
using Car_Showroom.DataAccess;

namespace Car_Showroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository carRepository;

        public HomeController(ILogger<HomeController> logger, ICarRepository carRepository)
        {
            _logger = logger;
            this.carRepository = carRepository;
        }

        public IActionResult Index()
        {
            List<Model> modelList =  carRepository.GetModels();
            return View(modelList);
        }
        public async Task<IActionResult> Details(int Id)
        {
            Model model = await carRepository.GetModel(Id);
            List<ModelsEngines> modelsEngines = carRepository.GetModelsEngines(Id);
            List<Engine> enginesList = await carRepository.GetEngineList(modelsEngines);

            List<ModelsTrims> modelsTrims = carRepository.GetModelsTrims(Id);
            List<Trim> trimsList = await carRepository.GetTrimList(modelsTrims);

            List<List<Option>> optionsList = new List<List<Option>>();
            foreach (var element in trimsList)
            {
                var trimOption = await carRepository.GetTrimsOptionsList(element.Id);
                var  option = await carRepository.GetOptionsList(trimOption);
                optionsList.Add(option);
            }

            ViewData["model"] = model;
            ViewData["enginesList"] = enginesList;
            ViewData["trimsList"] = trimsList;
            ViewData["optionsList"] = optionsList;

            return View();
        }


        public IActionResult Privacy(int modelId)
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
