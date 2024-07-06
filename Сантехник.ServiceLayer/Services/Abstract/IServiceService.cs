using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ServiceVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface IServiceService
    {
        Task AddServiceService(ServiceAddVM request);
        Task DeleteServiceAsync(int id);
        Task<List<ServiceListVM>> GetAllListAsync();
        Task<ServiceUpdateVM> GetServiceById(int id);
        Task UpdateServiceAsync(ServiceUpdateVM request);
    }
}
