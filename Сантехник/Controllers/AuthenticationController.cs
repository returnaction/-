using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Сантехник.EntityLayer.Identity.Entities;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.ServiceLayer.Helpers.Identity.EmailHelper;
using Сантехник.ServiceLayer.Helpers.Identity.ModelStateHelper;
using Сантехник.ServiceLayer.Services.Identity.Abstract;

namespace Сантехник.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly IValidator<SignUpVM> _signUpValidator;
        private readonly IValidator<LogInVM> _logInValidator;
        private readonly IValidator<ForgotPasswordVM> _forgotPasswordValidator;
        private readonly IValidator<ResetPasswordVM> _resetPasswordValidator;

        private readonly IMapper _iMapper;
        private readonly IAuthenticationCustomService _authenticationCustomService;


        public AuthenticationController(UserManager<AppUser> userManager, IValidator<SignUpVM> signUpValidator, IMapper iMapper, IValidator<LogInVM> logInValidator, SignInManager<AppUser> signInManager, IValidator<ForgotPasswordVM> forgotPasswordValidator, IValidator<ResetPasswordVM> resetPasswordValidator, IAuthenticationCustomService authenticationCustomService)
        {
            _userManager = userManager;
            _signInManager = signInManager;

            _signUpValidator = signUpValidator;
            _logInValidator = logInValidator;

            _iMapper = iMapper;
            _forgotPasswordValidator = forgotPasswordValidator;

            _resetPasswordValidator = resetPasswordValidator;
            _authenticationCustomService = authenticationCustomService;
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

            var user = _iMapper.Map<AppUser>(request); // this should go to service layer
            var userCreateRusult = await _userManager.CreateAsync(user, request.Password);
            if (!userCreateRusult.Succeeded)
            {
                ViewBag.Result = "NotSucceed";
                ModelState.AddModelErrorList(userCreateRusult.Errors);
                return View();
            }

            // if success;

            return RedirectToAction("LogIn", "Authentication");
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


        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVM request)
        {
            // validate the prompt
            var validation = await _forgotPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View(request);
            }

            var hasUser = await _userManager.FindByEmailAsync(request.Email);
            // can't find user
            if(hasUser is null)
            {
                ViewBag.Result = "UserDoesNotExist";
                ModelState.AddModelErrorList(new List<string> { "User does not exist!" });
                return View();
            }

            // found user
            await _authenticationCustomService.CreateResetCreadentialsAndSend(hasUser, HttpContext, Url, request);

            return RedirectToAction("LogIn", "Authentication");

        }


        public IActionResult ResetPassword(string userId, string token, List<string> errors)
        {
            TempData["UserId"] = userId;
            TempData["Token"] = token;

            if (errors.Any())
            {
                ViewBag.Result = "Error";
                ModelState.AddModelErrorList(errors);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVM request)
        {
            var userId = TempData["UserId"];
            var token = TempData["Token"];

            if (userId is null || token is null)
            {
                return RedirectToAction("LogIn", "Authentication");
            }

            var validation = await _resetPasswordValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                List<string> errors = validation.Errors.Select(x => x.ErrorMessage).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }

            var hasUser = await _userManager.FindByIdAsync(userId.ToString()!);
            if (hasUser is null)
            {
                return RedirectToAction("LogIn", "Authentication");
            }

            var resetPasswordResult = await _userManager.ResetPasswordAsync(hasUser!, token.ToString()!, request.Password);
            if (resetPasswordResult.Succeeded)
            {
                return RedirectToAction("LogIn", "Authentication");
            }
            else
            {
                List<string> errors = resetPasswordResult.Errors.Select(x => x.Description).ToList();
                return RedirectToAction("ResetPassword", "Authentication", new { userId, token, errors });
            }
        }


        public IActionResult AccessDenies()
        {
            return View();
        }
    }
}
