using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.RepositoryLayer.Context;
using Сантехник.RepositoryLayer.Repositories.Abstract;
using Сантехник.RepositoryLayer.Repositories.Concrete;
using Сантехник.RepositoryLayer.UnitOfWork.Abstract;



namespace Сантехник.RepositoryLayer.Extensions
{
    public static class RepositoryLayerExtensions
    {
        public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            services.AddScoped(typeof(IGenericRepositories<>), typeof(GenericRepositories<>));

            services.AddScoped<IUnitOfWork, Сантехник.RepositoryLayer.UnitOfWork.Concrete.UnitOfWork>();  // не знаю почему он использовался как тип не могу подключить.

            return services;
        }
    }
}


