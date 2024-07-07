using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.HomePageVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.HomePageValidation
{
    public class HomePageAddValidation : AbstractValidator<HomePageAddVM>
    {
        public HomePageAddValidation()
        {
            RuleFor(x => x.Header)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(5000);
            RuleFor(x => x.VideoLink)
                .NotNull()
                .NotEmpty();
        }
    }
}
