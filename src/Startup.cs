using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PersonelTakip.Models;
using PersonelTakip.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using PersonelTakip.Persistance;
using AutoMapper;
using PersonelTakip.Core;
using Puantaj.Extensions;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Localization;
using System.IO;
using Serilog;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace PersonelTakip
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, ApplicationRole>(options => options.Stores.MaxLengthForKeys = 128)
             .AddEntityFrameworkStores<ApplicationDbContext>()
             .AddDefaultTokenProviders()
             .AddErrorDescriber<LocalizedIdentityErrorDescriber>();

            services.AddSingleton(HtmlEncoder.Create(allowedRanges: new[] { UnicodeRanges.BasicLatin, UnicodeRanges.Latin1Supplement, UnicodeRanges.LatinExtendedA }));           
            services.AddLocalization(options => options.ResourcesPath = "Resources");



            // Add application services.
            services.AddTransient<IEmailSender, EmailSender>();

            services.AddMvc()
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
            .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization();
            services.AddAutoMapper();

            services.AddScoped<IPersonelRepository, PersonelRepository>();
            services.AddScoped<IPuantajRepository, PuantajRepository>();
            services.AddScoped<ISecenekListesiRepository, SecenekListesiRepository>();
            services.AddScoped<IUnvanRepository, UnvanRepository>();
            services.AddScoped<IHesaplamaRepository, HesaplamaRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            if (string.IsNullOrWhiteSpace(env.WebRootPath)) 
            env.WebRootPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot");
            
            var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json")
                        .Build();
            var logPath = Path.Combine("loglar","log.txt");

            Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(configuration)
            .WriteTo.File(logPath, rollingInterval: RollingInterval.Day)
            .CreateLogger();
            
            
            
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

        
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                 name: "default",
                 template: "{controller=Home}/{action=Index}/{id?}");
            });
            CreateRolesAndYonetici(serviceProvider).Wait();
        }


        private async Task CreateRolesAndYonetici(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            string[] roleNames = { "SistemYöneticisi", "ÜstDüzeyYetkili", "Yetkili", "Kullanıcı" };

            foreach (var role in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(role);
                if (!roleExist)
                {
                  await roleManager.CreateAsync(new ApplicationRole(role));
                }
            }
            var user = await userManager.FindByNameAsync("super.admin");
            if(user == null)
            {
                user = new ApplicationUser
                {
                    UserName = "super.admin",
                    Email = "super.admin"
                };
                await userManager.CreateAsync(user, "superAdmin.1958");

            }
            await userManager.AddToRoleAsync(user, "SistemYöneticisi");
        }
    }
}
