using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private readonly IValidator<PortfolioAddVM> _addValidator;
        private readonly IValidator<PortfolioUpdateVM> _updateValidator;

        public PortfolioController(IPortfolioService portfolioService, IValidator<PortfolioAddVM> addValidator, IValidator<PortfolioUpdateVM> updateValidator)
        {
            _portfolioService = portfolioService;
            _addValidator = addValidator;
            _updateValidator = updateValidator;
        }

        public async Task<IActionResult> GetPortfolioList()
        {
            var portfolioList = await _portfolioService.GetAllListAsync();
            return View(portfolioList);
        }

        public IActionResult AddPortfolio()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPortfolio(PortfolioAddVM request)
        {
            var validation = await _addValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _portfolioService.AddPortfolioService(request);
                return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
            }

            validation.AddToModelState(this.ModelState);
            return View(request);

        }

        public async Task<IActionResult> UpdatePortfolio(int id)
        {
            var portfolio = await _portfolioService.GetPortfolioById(id);
            return View(portfolio);
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePortfolio(PortfolioUpdateVM request)
        {
            var validation = await _updateValidator.ValidateAsync(request);
            if (validation.IsValid)
            {
                await _portfolioService.UpdatePortfolioAsync(request);
                return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
            }

            validation.AddToModelState(this.ModelState);
            return View();
        }

        public async Task<IActionResult> DeletePortfolio(int id)
        {
            await _portfolioService.DeletePortfolioAsync(id);
            return RedirectToAction("GetPortfolioList", "Portfolio", new { Area = ("Admin") });
        }
    }
}
