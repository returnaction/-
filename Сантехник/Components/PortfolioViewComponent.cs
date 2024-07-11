using Microsoft.AspNetCore.Mvc;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;
using Сантехник.ServiceLayer.Services.WebApplication.Concrete;

namespace Сантехник.Components
{
    public class PortfolioViewComponent : ViewComponent
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioViewComponent(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var portfolioListForUI = await _portfolioService.GetAllListForUIAsync();
            return View(portfolioListForUI);
        }
    }
}
