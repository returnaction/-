using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.Entities;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.RepositoryLayer.Context;
using Сантехник.ServiceLayer.Helpers.Identity.EmailHelper;

namespace Сантехник.ServiceLayer.Extensions.Identity
{
    public static class IdentityExtensions
    {
        public static IServiceCollection LoadIdentityExtensions(this IServiceCollection services, IConfiguration config)
        {

            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequiredLength = 10;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredUniqueChars = 2;
                options.Password.RequireDigit = true;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(15);
                options.Lockout.MaxFailedAccessAttempts = 15;
            })
                .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                var newCookie = new CookieBuilder();
                newCookie.Name = "PlumbingCompany";
                options.LoginPath = new PathString("/Authentication/Login");  
                options.LogoutPath = new PathString("/Authentication/Logout");
                options.AccessDeniedPath = new PathString("/Authentication/AccessDenied");// add thos later
                options.Cookie = newCookie;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60); // cooking expriration time
            });

            services.Configure<DataProtectionTokenProviderOptions>(opt => opt.TokenLifespan = TimeSpan.FromMinutes(60));

            services.AddScoped<IEmailSendMethod, EmailSendMethod>();

            services.Configure<GmailInformationVM>(config.GetSection("EmailSettings"));

            return services;
        }
    }
}
