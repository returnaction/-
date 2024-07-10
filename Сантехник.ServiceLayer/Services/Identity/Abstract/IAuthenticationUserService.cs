using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.EntityLayer.Identity.Entities;

namespace Сантехник.ServiceLayer.Services.Identity.Abstract
{
    public interface IAuthenticationUserService
    {
        Task<UserEditVM> FindUserAsync(HttpContext httpContext);
        Task<IdentityResult> UserEditAsync(UserEditVM request, AppUser user);
    }
}
