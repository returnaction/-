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
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IValidator<LogInVM> _logInValidator;

        private readonly IMapper _iMapper;

        public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper iMapper, IValidator<LogInVM> logInValidator, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _signUpValidator = signUpValidator;
            _logInValidator = logInValidator;

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

        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInVM request, string? returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Dashboard", new { Area = "Admin" });

            var validation = await _logInValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                ViewBag.Result = "NotSucceed";
                validation.AddToModelState(this.ModelState);
                return View(request);
            }

            // finding the user
            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            if (hasUser == null)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(new List<string> { "Email or Password is worng" });
                return View(request);
            }

            // let's signIn
            var logInResult = _signInManager.PasswordSignInAsync(hasUser, request.Password, request.RememberMe, true);

            if (logInResult.Result.Succeeded)
            {
                return Redirect(returnUrl!);
            }

            // if we didn't succeed;

            if (logInResult.Result.IsLockedOut)
            {
                ViewBag.Result = "LockedOut";
                ModelState.AddModelErrorList(new List<string> { "Your account is locked out for 3 minutes" });
                return View();
            }

            ViewBag.Result = "FailedAttempt";
            ModelState.AddModelErrorList(new List<string> { $"Email or Password is wrong! Failed attempt {await _userManager.GetAccessFailedCountAsync(hasUser)}" });
            return View();
        }
    }
}
