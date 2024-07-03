using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface ICategoryService
    {
        Task AddCategoryService(CategoryAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<CategoryListVM>> GetAllListAsync();
        Task<CategoryUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(CategoryUpdateVM request);
    }
}
