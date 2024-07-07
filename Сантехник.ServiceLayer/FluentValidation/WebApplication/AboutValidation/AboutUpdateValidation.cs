using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
    public class AboutUpdateValidation : AbstractValidator<AboutUpdateVM>
    {
        public AboutUpdateValidation()
        {
            RuleFor(x => x.Header)
                 .NotEmpty()
                 .NotNull()
                 .MaximumLength(5000);
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(5000);
            RuleFor(x => x.Clients)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.Projects)
                .NotNull()
                .NotEmpty()
                .GreaterThanOrEqualTo(0);
            RuleFor(x => x.HoursOfSupport)
               .NotNull()
               .NotEmpty()
               .GreaterThanOrEqualTo(0);
            RuleFor(x => x.HardWorkers)
               .NotNull()
               .NotEmpty()
               .GreaterThanOrEqualTo(0);
        }
    }
}
