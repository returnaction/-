using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM;

namespace Сантехник.ServiceLayer.Services.Abstract
{
    public interface ITestimonialService
    {
        Task AddCategoryService(TestimonialAddVM request);
        Task DeleteCategoryAsync(int id);
        Task<List<TestimonialListVM>> GetAllListAsync();
        Task<TestimonialUpdateVM> GetCategoryById(int id);
        Task UpdateCategoryAsync(TestimonialUpdateVM request);
    }
}
