using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly ITestimonialService _testimonialService;
        private readonly IValidator<TestimonialAddVM> _addTestimonial;
        private readonly IValidator<TestimonialUpdateVM> _updateTestimonial;

        public TestimonialController(ITestimonialService testimonialService, IValidator<TestimonialAddVM> addTestimonial, IValidator<TestimonialUpdateVM> updateTestimonial)
        {
            _testimonialService = testimonialService;
            _addTestimonial = addTestimonial;
            _updateTestimonial = updateTestimonial;
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
            var validation = await _addTestimonial.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _testimonialService.AddTestimonialService(request);
                return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
            }

            validation.AddToModelState(this.ModelState);
            return View(request);
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var testimonial = await _testimonialService.GetTestimonialById(id);
            return View(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(TestimonialUpdateVM request)
        {
            var validation = await _updateTestimonial.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _testimonialService.UpdateTestimonialAsync(request);
                return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
            }

            validation.AddToModelState(this.ModelState);
            return View(request);
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _testimonialService.DeleteTestimonialAsync(id);
            return RedirectToAction("GetTestimonialList", "Testimonial", new { Area = ("Admin") });
        }
    }
}
