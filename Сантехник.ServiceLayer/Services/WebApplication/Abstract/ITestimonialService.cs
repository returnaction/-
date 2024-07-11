using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM;

namespace Сантехник.ServiceLayer.Services.WebApplication.Abstract
{
    public interface ITestimonialService
    {
        Task AddTestimonialService(TestimonialAddVM request);
        Task DeleteTestimonialAsync(int id);
        Task<List<TestimonialListVM>> GetAllListAsync();
        Task<TestimonialUpdateVM> GetTestimonialById(int id);
        Task UpdateTestimonialAsync(TestimonialUpdateVM request);

        Task<List<TestimonialListForUI>> GetAllListForUIAsync();
    }
}
