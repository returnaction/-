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
        Task AddCategoryService(ServiceAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<ServiceListVM>> GetAllListAsync();
        Task<ServiceUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(ServiceUpdateVM request);
    }
}
