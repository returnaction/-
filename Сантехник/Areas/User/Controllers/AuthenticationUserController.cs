using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Сантехник.EntityLayer.Identity.Entities;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.ServiceLayer.Helpers.Identity.ModelStateHelper;
using Сантехник.ServiceLayer.Services.Identity.Abstract;

namespace Сантехник.Areas.User.Controllers
{
    [Authorize(Roles = "Member, SuperAdmin")]
    [Area("User")]
    public class AuthenticationUserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        private readonly IValidator<UserEditVM> _userEditValidator;

        private readonly IAuthenticationUserService _authenticationUserService;

        public AuthenticationUserController(UserManager<AppUser> userManager, IMapper mapper, IValidator<UserEditVM> userEditValidator, IAuthenticationUserService authenticationUserService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _userEditValidator = userEditValidator;
            _authenticationUserService = authenticationUserService;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> UserEdit()
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);
            var userEditVM = _mapper.Map<UserEditVM>(user);

            return View(userEditVM);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserEditVM request)
        {
            var user = await _userManager.FindByNameAsync(User.Identity!.Name!);


            var validation = await _userEditValidator.ValidateAsync(request);
            if (!validation.IsValid)
            {
                validation.AddToModelState(this.ModelState);
                return View();
            }



            var userEditResult = await _authenticationUserService.UserEditAsync(request, user!);
            if (!userEditResult.Succeeded)
            {
                ViewBag.Result = "FailedUserEdit";
                ModelState.AddModelErrorList(userEditResult.Errors);
                return View();
            }
            ViewBag.Username = user!.UserName;

            return RedirectToAction("Index", "Dashboard", new { Area = "User" });
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/Home/Index");
            
        }
    }
}
