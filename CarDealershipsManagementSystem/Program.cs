using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAddressRepository, SQLAddressRepository>();
builder.Services.AddScoped<ICarRepository, SQLCarRepository>();
builder.Services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
builder.Services.AddScoped<IDealershipRepository, SQLDealershipRepository>();
builder.Services.AddScoped<IEquipmentRepository, SQLEquipmentRepository>();
builder.Services.AddScoped<IModelRepository, SQLModelRepository>();
builder.Services.AddScoped<IEngineRepository, SQLEngineRepository>();
builder.Services.AddScoped<IOptionRepository, SQLOptionRepository>();
builder.Services.AddScoped<IOrderRepository, SQLOrderRepository>();
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");
app.MapControllerRoute(
    name: "Admin",
    pattern: "{controller=Admin}/{action=Index}");
app.MapControllerRoute(
    name: "Manager",
    pattern: "{controller=Manager}/{action=Index}");
app.MapControllerRoute(
    name: "Employee",
    pattern: "{controller=Employee}/{action=Index}");
app.MapRazorPages();

app.Run();
