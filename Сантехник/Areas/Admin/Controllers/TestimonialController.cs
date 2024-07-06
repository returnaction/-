using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM;
using Сантехник.ServiceLayer.Services.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        
        public async Task<IActionResult> GetTestimonialList()
        {
            var testimonialList = await _testimonialService.GetAllListAsync();
            return View(testimonialList);
        }

        public IActionResult AddTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddTestimonial(TestimonialAddVM request)
        {
            await _testimonialService.AddTestimonialService(request);
            return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetTestimonialById(id);
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateVM request)
        {
            await _testimonialService.UpdateTestimonialAsync(request);
            return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
        }
    }
}
