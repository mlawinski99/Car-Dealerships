using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Car_Showroom.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace CarDealershipsManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IModelRepository modelRepository;

        public AdminController(
            ILogger<HomeController> logger,
            IModelRepository modelRepository
            )
        {
            _logger = logger;
            this.modelRepository = modelRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ModelList()
        {
            return View("Models/ModelList");
        }
        public IActionResult AddNewModel()
        {
            return View("Models/AddNewModel");
        }
        public IActionResult AddNewEngine()
        {
            return View("Models/AddNewEngine");
        }
        public IActionResult AddNewOption()
        {
            return View("Models/AddNewOption");
        }
        public IActionResult AddNewEquipment()
        {
            return View("Models/AddNewEquipment");
        }
        public IActionResult EmployeeList()
        {
            return View("Employees/EmployeeList");
        }
        public IActionResult AddNewEmployee()
        {
            return View("Employees/AddNewEmployee");
        }
        public IActionResult DealershipList()
        {
            return View("Dealerships/DealershipList");
        }
        public IActionResult AddNewDealership()
        {
            return View("Dealerships/AddNewDealership");
        }
    }
}