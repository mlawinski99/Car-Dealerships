using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Showroom.DataAccess;
using Car_Showroom.Models;
using Car_Showroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Car_Showroom.Controllers
{
    public class ManagementController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAddressRepository addressRepository;
        private readonly IEmployeeRepository employeeRepository;

        public ManagementController(UserManager<ApplicationUser> userManager,
            IAddressRepository addressRepository,
             IEmployeeRepository employeeRepository
            )
        {
            this.userManager = userManager;
            this.addressRepository = addressRepository;
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public IActionResult EmployeeList()
        {
            var employeeList = employeeRepository.GetEmployeeList();
            return View(employeeList);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    Country = model.Country,
                    CountryCode = model.CountryCode,
                    District = model.District,
                    Street = model.Street,
                    ApartmentNumber = model.ApartmentNumber,
                    PostalCode = model.PostalCode,
                    City = model.City
                };

                addressRepository.Add(address);
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Login,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    AddressId = address.Id
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var employee = new Employee
                    {
                        ContractType = model.ContractType,
                        EmploymentDate = model.EmploymentDate,
                        JobPosition = model.JobPosition,
                        Salary = model.Salary,
                        ApplicationUserId = user.Id
                        //@todo
                        //ManagerId = id tworzacego konto
                        //DealerId = ??
                    };
                    employeeRepository.Add(employee);
                    return View(model);
                    //@todo
                    //redirect lista workerow
                }
                return View(model);
            }
            return View();
        }
    }
}

