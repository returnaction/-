using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.RepositoryLayer.Context;

namespace Сантехник.RepositoryLayer.Extensions
{
    public static class RepositoryLayerExtensions
    {
        public static IServiceCollection LoadRepositoryLayerExtensions(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(option => option.UseSqlServer(config.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}


