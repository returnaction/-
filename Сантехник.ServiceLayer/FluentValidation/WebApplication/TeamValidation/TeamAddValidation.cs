using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TeamVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.TeamValidation
{
    public class TeamAddValidation : AbstractValidator<TeamAddVM>
    {
        public TeamAddValidation()
        {
            RuleFor(x => x.FullName)
              .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
              .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
              .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("FullName", 5000));
            RuleFor(x => x.Title)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Title", 200));
            RuleFor(x => x.FileName)
               .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileName"))
               .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileName"));
            RuleFor(x => x.FileType)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileName"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileName"));
        }
    }
}
