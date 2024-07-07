using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.Identity;
using Сантехник.EntityLayer.Identity.ViewModels;

namespace Сантехник.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> SignUp(SignUpVM request)
        //{
        //    return View();
        //}
    }
}
