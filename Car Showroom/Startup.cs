using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Car_Showroom.DataAccess;
using Car_Showroom.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Car_Showroom
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
                services.AddDbContext<CarDealershipsContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

                services.AddIdentity<ApplicationUser, IdentityRole>(options => {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 6;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = true;
                    options.Password.RequireLowercase = true;
                })
                    .AddEntityFrameworkStores<CarDealershipsContext>()
                    .AddDefaultTokenProviders();
            
            services.AddScoped<ICustomerRepository, SQLCustomerRepository>();
            services.AddScoped<IAddressRepository, SQLAddressRepository>();
            services.AddScoped<ICarRepository, SQLCarRepository>();
            services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>();
            services.AddScoped<IDealerRepository, SQLDealerRepository>();
            services.AddScoped<IModelRepository, SQLModelRepository>();
            services.AddScoped<IModelsTrimsRepository, SQLModelsTrimsRepository>();
            services.AddScoped<IModelsEnginesRepository, SQLModelsEnginesRepository>();
            services.AddScoped<IEngineRepository, SQLEngineRepository>();
            services.AddScoped<IOptionRepository, SQLOptionRepository>();
            services.AddScoped<ITrimRepository, SQLTrimRepository>();
            services.AddScoped<ITrimsOptions, SQLTrimsOptionsRepository>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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

            app.UseAuthorization();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
