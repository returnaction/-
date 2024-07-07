using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.Identity;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.ServiceLayer.Helpers.Identity;

namespace Сантехник.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IMapper _iMapper;

        public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper iMapper)
        {
            _userManager = userManager;
            _signUpValidator = signUpValidator;
            _iMapper = iMapper;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpVM request)
        {
            var validation = await _signUpValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(request);
            }

            var user = _iMapper.Map<AppUser>(request);
            var userCreateRusult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateRusult.Succeeded)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(userCreateRusult.Errors);
                return View();
            }

            // if success;

            return RedirectToAction("LogIn", "Authenticaion");
        }
    }
}
