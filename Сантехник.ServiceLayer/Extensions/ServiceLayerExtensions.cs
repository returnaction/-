using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Сантехник.ServiceLayer.FluentValidation.WebApplication.HomePageValidation;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Concrete;

namespace Сантехник.ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            //services.AddScoped<IAboutService, AboutService>(); silly way to add services. One bellow is better.

            var types = Assembly.GetExecutingAssembly().GetTypes().Where(x => x.IsClass && !x.IsAbstract && x.Name.EndsWith("Service"));

            foreach (var serviceType in types)
            {
                var iServiceType = serviceType.GetInterfaces().FirstOrDefault(x => x.Name == $"I{serviceType.Name}");

                if (iServiceType != null)
                {
                    services.AddScoped(iServiceType, serviceType);
                }
            }

            services.AddFluentValidationAutoValidation(option => option.DisableDataAnnotationsValidation = true);

            //this method finds that class in out assembly and select it and add the rest of validators in out project. (Maybe not )
            services.AddValidatorsFromAssemblyContaining<HomePageAddValidation>();
            return services;
        }

    }
}
