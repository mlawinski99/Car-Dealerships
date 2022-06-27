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
    [Authorize(Roles = "Administrator, Manager")]
    public class ManagerController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public ManagerController(
            ILogger<HomeController> logger
            )
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EmployeeList()
        {
            return View("Employees/EmployeeList");
        }
        public IActionResult AddNewEmployee()
        {
            return View("Employees/AddNewEmployee");
        }

        public IActionResult CustomerList()
        {
            return View("Customers/CustomerList");
        }

        public IActionResult OrderList()
        {
            return View("Orders/OrderList");
        }
    }
}