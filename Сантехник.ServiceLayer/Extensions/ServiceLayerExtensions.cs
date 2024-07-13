using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Сантехник.ServiceLayer.Extensions.Identity;
using Сантехник.ServiceLayer.FluentValidation.WebApplication.HomePageValidation;
using Сантехник.ServiceLayer.Helpers.Generic.Image;

namespace Сантехник.ServiceLayer.Extensions
{
    public static class ServiceLayerExtensions
    {
        public static IServiceCollection LoadServiceLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.LoadIdentityExtensions(config);
            

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
            services.AddScoped<IImageHelper, ImageHelper>();
            return services;
        }

    }
}
