using Microsoft.AspNetCore.Mvc;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Components
{
    public class HomePageViewComponent : ViewComponent
    {
        private readonly IHomePageService _homePageService;

        public HomePageViewComponent(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var homePageList = await _homePageService.GetAllListForUI();
            return View(homePageList);
        }
    }
}
