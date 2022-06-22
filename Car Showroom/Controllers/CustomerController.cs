using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Car_Showroom.DataAccess;
using Car_Showroom.Models;
using Car_Showroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace Car_Showroom.Controllers
{
    public class CustomerController : Controller
    {
        public CustomerController()
        {
        }

        [HttpGet]
        public IActionResult Panel()
        {
            return View();
        }
    }
}

