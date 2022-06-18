﻿using System;
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

namespace Car_Showroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICarRepository carRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        public HomeController(ILogger<HomeController> logger, 
            ICarRepository carRepository, 
            UserManager<ApplicationUser> userManager,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            this.carRepository = carRepository;
            this.userManager = userManager;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
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
        public async Task<IActionResult> CreateOrder(int Id, double price, double discount, PaymentType paymentType, ShipmentType shipmentType)
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            int customerId = customerRepository.GetCustomerId(applicationUser.Id);

            var order = new Order
            {
                CustomerId = customerId,
                Status = 0,
                Price = price,
                Discount = discount,
                PaymentType = paymentType,
                SubmissionDate = DateTime.Now,
                FinalizationDate = DateTime.Now.AddDays(7),
                ShipmentType = shipmentType
            };
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
