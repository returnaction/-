using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.SocialMediaVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.SocialMediaValidation
{
    public class SocialMediaUpdateValidation : AbstractValidator<SocialMediaUpdateVM>
    {
        public SocialMediaUpdateValidation()
        {
        }
    }
}
