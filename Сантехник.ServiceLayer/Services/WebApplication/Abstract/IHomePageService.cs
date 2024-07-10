using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.HomePageVM;

namespace Сантехник.ServiceLayer.Services.WebApplication.Abstract
{
    public interface IHomePageService
    {
        Task AddHomePageService(HomePageAddVM request);
        Task DeleteHomePageAsync(int id);
        Task<List<HomePageListVM>> GetAllListAsync();
        Task<HomePageUpdateVM> GetHomePageById(int id);
        Task UpdateHomePageAsync(HomePageUpdateVM request);

        // UI Service methods
        Task<List<HomePageVMForUI>> GetAllListForUI();
    }
}
