using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Area.Admin.Controllers
{
    [Authorize(Roles = "SuperAdmin")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly IDashBoardService _dashboardService;

        public DashboardController(IDashBoardService dashboardService)
        {
            _dashboardService = dashboardService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Services = await _dashboardService.GetAllServicesCountAsync();
            ViewBag.Teams = await _dashboardService.GetAllTeamsCountAsync();
            ViewBag.Testimonals = await _dashboardService.GetAllTestimonalsCountAsync();
            ViewBag.Categories = await _dashboardService.GetAllCategoriesCountAsync();
            ViewBag.Portfolios = await _dashboardService.GetAllPortfoliosCountAsync();
            ViewBag.Users = _dashboardService.GetAllUsersCountAsync();

            return View();
        }
    }
}
