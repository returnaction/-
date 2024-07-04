using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.HomePageVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface IHomePageService
    {
        Task AddCategoryService(HomePageAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<HomePageListVM>> GetAllListAsync();
        Task<HomePageUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(HomePageUpdateVM request);
    }
}
