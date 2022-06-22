using System;
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
using Car_Showroom.ViewModels;

namespace Car_Showroom.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModelRepository modelRepository;
        private readonly ITrimRepository trimRepository;
        public HomeController(
            IModelRepository modelRepository,
            ITrimRepository trimRepository
            )
        {
            this.modelRepository = modelRepository;
            this.trimRepository = trimRepository;
        }

        public IActionResult Index()
        {
            List<Model> modelList = modelRepository.GetModelList();
            return View(modelList);
        }
        public IActionResult Details(int id)
        {
            Model model = modelRepository.Get(id);
            List<Engine> engineList = modelRepository.GetEnginesAvailableForModel(model);
            List<Trim> trimList = modelRepository.GetTrimsAvailableForModel(model);

            var trimOptionTupleList = new List<Tuple<Trim, List<Option>>>();
            foreach (var trim in trimList)
            {
                var optionsInTrim = trimRepository.GetOptionsInTrim(trim);
                trimOptionTupleList.Add(new Tuple<Trim, List<Option>>(trim, optionsInTrim));
            }

            ViewData["model"] = model;
            ViewData["engines"] = engineList;
            ViewData["trims"] = trimList;
            ViewData["trimOptionTupleList"] = trimOptionTupleList;
            return View();
        }
        /*
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder(CreateCarViewModel model)
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            int customerId = customerRepository.GetCustomerAppUserId(applicationUser.Id);

            var details = new Details 
            { 
                ProductionYear = model.ProductionYear,
                Weight = model.Weight
            };
            detailsRepository.Add(details);
            var order = new Order
            {
                CustomerId = customerId,
                Status = 0,
                Price = model.Price,
                Discount = model.Discount,
                PaymentType = model.PaymentType,
                SubmissionDate = DateTime.Now,
                FinalizationDate = DateTime.Now.AddDays(365),
                ShipmentType = model.ShipmentType
            };
            var car = new Car
            {
                ModelId = model.ModelId,
                DealerId = model.DealerId,
                OrderId = order.Id,
                DetailsId = details.Id,
                TrimId = model.TrimId,
                EngineId = model.EngineId
            };
            detailsRepository.Add(details);
            carRepository.Add(car);
            orderRepository.Add(order);
            return View();
        }
        */
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
