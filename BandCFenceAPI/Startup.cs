﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BandCFenceAPI.Core.Models;
using BandCFenceAPI.Core.Services;
using BandCFenceAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BandCFenceAPI
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
            services.AddDbContext<AppDbContext>();

            services.AddIdentity<AppUser, IdentityRole>()
             .AddEntityFrameworkStores<AppDbContext>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IFenceRepository, FenceRepository>();

            services.AddScoped<IFenceService, FenceService>();

            services.AddScoped<IBuilderRepository, BuilderRepository>();

            services.AddScoped<IBuilderService, BuilderService>();



            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseMvc();

            // create admin user if it doesn't already exist
            SeedAdminUser(userManager, roleManager);
        }

        private void SeedAdminUser(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            // create an Admin role, if it doesn't already exist
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {
                var adminRole = new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "Admin".ToUpper()
                };
                var result = roleManager.CreateAsync(adminRole).Result;
            }

            // create an Admin user, if it doesn't already exist
            //if (userManager.FindByNameAsync("admin").Result == null)
            //{
            //    AppUser user = new AppUser
            //    {
            //        UserName = "admin@test.com",
            //        Email = "admin@test.com"
            //    };

            //    // add the Admin user to the Admin role
            //    IdentityResult result = userManager.CreateAsync(user, "AdminPassword123!").Result;

            //    if (result.Succeeded)
            //    {
            //        userManager.AddToRoleAsync(user, "Admin").Wait();
            //    }
            //}
        }
    }
}
