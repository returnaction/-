using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.Entities;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.ServiceLayer.Helpers.Identity.EmailHelper;
using Сантехник.ServiceLayer.Services.Identity.Abstract;

namespace Сантехник.ServiceLayer.Services.Identity.Concrete
{
    public class AuthenticationCustomService : IAuthenticationCustomService
    {
        private readonly IEmailSendMethod _email;
        private readonly UserManager<AppUser> _userManager;

        public AuthenticationCustomService(IEmailSendMethod email, UserManager<AppUser> userManager)
        {
            _email = email;
            _userManager = userManager;
        }

        public async Task CreateResetCreadentialsAndSend(AppUser user, HttpContext httpContext, IUrlHelper url, ForgotPasswordVM request)
        {
            string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var passwordResetLink = url.Action("ResetPassword", "Authentication", new { userId = user.Id, token = resetToken }, httpContext.Request.Scheme);

            await _email.SendPasswordResetLinkWithToken(passwordResetLink!, request.Email);
        }
    }
}
