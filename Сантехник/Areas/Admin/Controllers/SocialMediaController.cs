using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM;
using Сантехник.ServiceLayer.Services.WebApplication.Abstract;

namespace Сантехник.Areas.Admin.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class SocialMediaController : Controller
    {
        private readonly ISocialMediaService _socialMediaService;

        public SocialMediaController(ISocialMediaService socialMediaService)
        {
            _socialMediaService = socialMediaService;
        }

        public async Task<IActionResult> GetSocialMediaList()
        {
            var socialMediaList = await _socialMediaService.GetAllListAsync();
            return View(socialMediaList);
        }

        public IActionResult AddSocialMedia()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialMedia(SocialMediaAddVM request)
        {
            await _socialMediaService.AddSocialMediaService(request);
            return RedirectToAction("GetSocialMediaList", "SocialMedia", new { Area = ("Admin") });
        }

        public async Task<IActionResult> UpdateSocialMedia(int id)
        {
            var socialMedia = await _socialMediaService.GetSocialMediaById(id);
            return View(socialMedia);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateSocialMedia(SocialMediaUpdateVM request)
        {
            await _socialMediaService.UpdateSocialMediaAsync(request);
            return RedirectToAction("GetSocialMediaList", "SocialMedia", new { Area = ("Admin") });
        }

        public async Task<IActionResult> DeleteSocialMedia(int id)
        {
            await _socialMediaService.DeleteSocialMediaAsync(id);
            return RedirectToAction("GetSocialMediaList", "SocialMedia", new { Area = ("Admin") });
        }

    }
}
