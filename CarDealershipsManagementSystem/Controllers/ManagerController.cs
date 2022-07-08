using CarDealershipsManagementSystem.Models;
using CarDealershipsManagementSystem.ViewModels;
using CarDealershipsManagementSystem.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf;
using Syncfusion.Drawing;

namespace CarDealershipsManagementSystem.Controllers
{
    [Authorize(Roles = "Administrator, Manager")]
    public class ManagerController : Controller
    {
        UserManager<ApplicationUser> userManager;
        RoleManager<IdentityRole> roleManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IEmployeeRepository employeeRepository;
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IAddressRepository addressRepository;

        public ManagerController(
            ILogger<HomeController> logger,
            UserManager<ApplicationUser> userManager,
             IEmployeeRepository employeeRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository,
            IAddressRepository addressRepository,
            RoleManager<IdentityRole> roleManager
            )
        {
            _logger = logger;
            this.userManager = userManager;
            this.employeeRepository = employeeRepository;
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.addressRepository = addressRepository;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> EmployeeList()
        {
            ApplicationUser managerApplicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(managerApplicationUser.Id);
            var employeeList = employeeRepository.GetEmployeeListForEmployeeDealership(manager);

            ViewBag.employeeList = employeeList;
            return View("Employees/EmployeeList");
        }
        [HttpGet]
        public IActionResult AddNewEmployee()
        {

            return View("Employees/AddNewEmployee");
        }
        [HttpPost]
        public async Task<IActionResult> AddNewEmployee(CreateEmployeeViewModel model)
        {

            if (ModelState.IsValid)
            {
                var address = new Address
                {
                    AddressCountry = model.AddressCountry,
                    AddressCountryCode = model.AddressCountryCode,
                    AddressDistrict = model.AddressDistrict,
                    AddressStreet = model.AddressStreet,
                    AddressApartmentNumber = model.AddressApartmentNumber,
                    AddressPostalCode = model.AddressPostalCode,
                    AddressCity = model.AddressCity
                };

                addressRepository.Add(address);
                var user = new ApplicationUser
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = address,
                    PhoneNumber = model.PhoneNumber,
                    Pesel = model.Pesel,
                    BirthDate = model.BirthDate
                };
                string Pass = string.Concat(model.FirstName.AsSpan(0, 3), model.LastName.AsSpan(0, 3), model.Pesel.AsSpan(0, 3), "!");
                var result = await userManager.CreateAsync(user, Pass);
                if (result.Succeeded)
                {
                    ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
                    var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);

                    var employee = new Employee
                    {
                        EmployeeContractType = model.EmployeeContractType,
                        EmployeeStartDate = model.EmployeeStartDate,
                        EmployeeFinishDate = model.EmployeeFinishDate,
                        EmployeeJobPosition = model.EmployeeJobPosition,
                        EmployeeSalary = model.EmployeeSalary,
                        ApplicationUser = user,
                        Dealership = manager.Dealership
                    };
                    employeeRepository.Add(employee);
                    var roleExists = await roleManager.RoleExistsAsync(employee.EmployeeJobPosition);

                    if (!roleExists)
                    {
                        IdentityRole identityRole = new IdentityRole
                        {
                            Name = model.EmployeeJobPosition
                        };
                        await roleManager.CreateAsync(identityRole);
                    }
                    await userManager.AddToRoleAsync(user, employee.EmployeeJobPosition);
                    ViewBag.message = "Employee " + model.Email + " added successfully with password " + Pass;
                    ViewBag.employeeList = employeeRepository.GetEmployeeListForEmployeeDealership(manager);
                    return View("Employees/EmployeeList");
                }
                ViewBag.message = "Something went wrong, employee not added";
                return View("Employees/AddNewEmployee");
            }
            ViewBag.message = "Something went wrong, employee not added";
            return View("Employees/AddNewEmployee");
        }

        public async Task<IActionResult> CustomerList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            var customerList = customerRepository.GetCustomerList();
            var customersOfDealership = new List<Customer>();

            foreach (var customer in customerList)
            {
                foreach (var order in customer.Orders)
                {
                    if (order.DealershipEmployee.Dealership.DealershipId == manager.Dealership.DealershipId)
                    {
                        customersOfDealership.Add(customer);
                        break;
                    }
                }
            }

            ViewBag.customerList = customersOfDealership;
            return View("Customers/CustomerList");
        }

        public async Task<IActionResult> OrderList()
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            var customerList = customerRepository.GetCustomerList();
            var ordersOfDealership = new List<Order>();

            foreach (var customer in customerList)
            {
                foreach (var order in customer.Orders)
                {
                    if (order.DealershipEmployee.Dealership.DealershipId == manager.Dealership.DealershipId)
                    {
                        ordersOfDealership.Add(order);
                    }
                }
            }

            ViewBag.orderList = ordersOfDealership;
            return View("Orders/OrderList");
        }

        [HttpGet]
        public IActionResult CreateRaport()
        {
            return View("Orders/CreateRaport");
        }
        public async Task<IActionResult> CreatePDF(CreatePDFViewModel model)
        {
            ApplicationUser applicationUser = await userManager.GetUserAsync(HttpContext.User);
            var manager = employeeRepository.GetEmployeeByApplicationUserId(applicationUser.Id);
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGraphics graphics = page.Graphics;
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 18);
            PdfFont fontSmaller = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            string dataToSave = null;
            var orderList = orderRepository.GetOrdersForDealershipEmployee(manager)
                .Where(o => (o.OrderFinalizationDate != null))
                .Where(o => (o.OrderSubmissionDate >= model.StartDate))
                .Where(o => (o.OrderFinalizationDate <= model.EndDate));
            
            foreach(var order in orderList)
            {
                dataToSave += "Numer Zamowienia: " + order.OrderId.ToString() + " Price: " + order.OrderPrice + " PLN\n";
            }
            dataToSave += "\n\nDochod: "+ orderList.Sum(o => o.OrderPrice)+" PLN";
            graphics.DrawString("Raport sprzedazy!\n\n", font, PdfBrushes.Black, new PointF(0, 0));
            graphics.DrawString(dataToSave, fontSmaller, PdfBrushes.Black, new PointF(0, 100));
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            //Set the position as '0'.
            stream.Position = 0;
            //Download the PDF document in the browser
            FileStreamResult fileStreamResult = new FileStreamResult(stream, "application/pdf");

            fileStreamResult.FileDownloadName = "Raport.pdf";
            return fileStreamResult;
        }
    }
}