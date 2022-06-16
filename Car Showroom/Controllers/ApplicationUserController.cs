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
                var address = new Address();
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

        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid && model.Password != model.NewPassword)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);
                var passwordValidator = new PasswordValidator<ApplicationUser>();
                var result = await passwordValidator.ValidateAsync(userManager, user, model.Password);
                if (!result.Succeeded)
                    return View();

                await userManager.ChangePasswordAsync(user, model.Password, model.NewPassword);
                await signInManager.RefreshSignInAsync(user);
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public IActionResult ChangeEmail()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeEmail(ChangeEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.GetUserAsync(HttpContext.User);

                var passwordValidator = new PasswordValidator<ApplicationUser>();
                var result = await passwordValidator.ValidateAsync(userManager, user, model.Password);
                if (!result.Succeeded)
                    return View();
                //@todo
                var token = await userManager.GenerateChangeEmailTokenAsync(user, model.Email);
                var s = await userManager.ChangeEmailAsync(user, model.Email, token);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult ChangeData()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ChangeData(ApplicationUser model)
        {
            //@todo
            return View();
        }
        
    }
}
