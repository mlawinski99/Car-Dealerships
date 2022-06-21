using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Car_Showroom.Controllers
{
    public class PanelController : Controller
    {
        public IActionResult AdminPanel()
        {
            return View();
        }

        public IActionResult CustomerPanel()
        {
            return View();
        }

        public IActionResult DealershipEmployeePanel()
        {
            return View();
        }
        public IActionResult ServiceEmployeePanel()
        {
            return View();
        }
        public IActionResult ManagerPanel()
        {
            return View();
        }
    }
}
