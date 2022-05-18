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
        public async Task<IActionResult> Details(int modelId)
        {
            Car car = await carRepository.GetCar(modelId);
            return View(car);
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
