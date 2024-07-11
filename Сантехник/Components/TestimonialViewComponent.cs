using Microsoft.AspNetCore.Mvc;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Concrete;

namespace Сантехник.Components
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialViewComponent(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonialListForUI = await _testimonialService.GetAllListForUIAsync();
            return View(testimonialListForUI);
        }
    }
}
