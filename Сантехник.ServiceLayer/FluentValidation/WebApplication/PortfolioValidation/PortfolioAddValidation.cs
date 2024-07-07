using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
    public class PortfolioAddValidation : AbstractValidator<PortfolioAddVM>
    {
        public PortfolioAddValidation()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(x => x.FileName)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.FileType)
                .NotNull()
                .NotEmpty();

            // maybe add photo later
            //RuleFor(x => x.Photo)
            //    .NotNull()
            //    .NotEmpty();
        }
    }
}
