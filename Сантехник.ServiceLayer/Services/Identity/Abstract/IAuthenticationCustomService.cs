using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity;
using Сантехник.EntityLayer.Identity.ViewModels;

namespace Сантехник.ServiceLayer.Services.Identity.Abstract
{
    public interface IAuthenticationCustomService
    {
        Task CreateResetCreadentialsAndSend(AppUser user, HttpContext httpContext, IUrlHelper url, ForgotPasswordVM request);
    }
}
