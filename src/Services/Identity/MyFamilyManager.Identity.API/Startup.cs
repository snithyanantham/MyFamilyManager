using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Threading.Tasks;
using IdentityModel;
using IdentityServer4.EntityFramework.DbContexts;
using IdentityServer4.EntityFramework.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MyFamilyManager.Identity.API.Data;
using MyFamilyManager.Identity.API.Models;
using MyFamilyManager.Identity.API.Services;

namespace MyFamilyManager.Identity.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        string migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name;


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowOrigins",
                    builder =>
                    {
                        builder.WithOrigins("https://localhost:44303")
                        .AllowAnyMethod()
                        .AllowCredentials()
                        .AllowAnyHeader();
                    });
            });
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));

            services.AddDbContext<ApplicationDbContext>(options =>
             options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IEmailSender, EmailSender>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
                {
                    options.Password.RequiredLength = 8;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedEmail = false;
                })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            var builder = services.AddIdentityServer()
               //.AddInMemoryIdentityResources(Config.Ids)
               //.AddInMemoryApiResources(Config.Apis)
               //.AddInMemoryClients(Config.Clients)
               .AddConfigurationStore(options =>
               {
                   options.ConfigureDbContext = b => b.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                       mysql => mysql.MigrationsAssembly(migrationsAssembly));
               })
               .AddOperationalStore(options =>
               {
                   options.ConfigureDbContext = b => b.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                       mysql => mysql.MigrationsAssembly(migrationsAssembly));
                   options.EnableTokenCleanup = true;
               })
               .AddAspNetIdentity<ApplicationUser>();

            builder.AddDeveloperSigningCredential();

            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = $"/Account/Login";
            //    options.LogoutPath = $"/Account/Logout";
            //    options.AccessDeniedPath = $"/Account/AccessDenied";
            //});

            services.AddControllersWithViews();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                // SeedData.InitializeDatabase(app);
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseIdentityServer();

            app.UseCors("AllowOrigins");
            // app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }

       
    }

}
