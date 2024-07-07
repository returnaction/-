using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.TeamValidation
{
    public class TeamUpdateValidation : AbstractValidator<TeamUpdateVM>
    {
        public TeamUpdateValidation()
        {
            RuleFor(x => x.FullName)
             .NotNull()
             .NotEmpty()
             .MaximumLength(200);
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
        }
    }
}
