using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.HomePageVM;
using Сантехник.ServiceLayer.Services.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomePageController : Controller
    {
        private readonly IHomePageService _homePageService;

        public HomePageController(IHomePageService homePageService)
        {
            _homePageService = homePageService;
        }

        public async Task<IActionResult> GetHomePageList()
        {
            var homePageList = await _homePageService.GetAllListAsync();
            return View(homePageList);
        }

        public IActionResult AddHomePage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddHomePage(HomePageAddVM request)
        {
            await _homePageService.AddHomePageService(request);
            return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
        }

        public async Task<IActionResult> UpdateHomePage(int id)
        {
            var homePage = await _homePageService.GetHomePageById(id);
            return View(homePage);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateHomePage(HomePageUpdateVM request)
        {
            await _homePageService.UpdateHomePageAsync(request);
            return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteHomePage(int id)
        {
            await _homePageService.DeleteHomePageAsync(id);
            return RedirectToAction("GetHomePageList", "HomePage", new { Area = ("Admin") });
        }
    }
}
