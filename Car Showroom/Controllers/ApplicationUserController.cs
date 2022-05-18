using Car_Showroom.DataAccess;
using Car_Showroom.Models;
using Car_Showroom.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IAddressRepository addressRepository;
        private readonly ICustomerRepository customerRepository;
        public ApplicationUserController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, IAddressRepository addressRepository,
            ICustomerRepository customerRepository)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.addressRepository = addressRepository;
            this.customerRepository = customerRepository;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Login, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    /*
                    Country = model.Country,
                    CountryCode = model.CountryCode,
                    District = model.District,
                    Street = model.Street,
                    ApartmentNumber = model.ApartmentNumber,
                    PostalCode = model.PostalCode,
                    City = model.City
                    */
                };
                var addressResult = addressRepository.Add(address);
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Login,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    /*
                    Pesel = model.Pesel,
                    PhoneNumber = model.PhoneNumber,
                    BirthDate = model.BirthDate,
                    */
                    AddressId = addressResult.Id
                };
                var result = await userManager.CreateAsync(user, model.Password);         
                if (result.Succeeded)
                {
                    var customer = new Customer
                    {
                        CustomerType = CustomerType.Normal,
                        ApplicationUserId = user.Id
                    };
                    customerRepository.Add(customer);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                //@todo
                //errors

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }
    }
}
