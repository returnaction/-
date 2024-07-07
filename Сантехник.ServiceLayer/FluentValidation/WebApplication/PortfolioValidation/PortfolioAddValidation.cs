using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.PortfolioVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
    public class PortfolioAddValidation : AbstractValidator<PortfolioAddVM>
    {
        public PortfolioAddValidation()
        {
            RuleFor(x => x.Title)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Title", 200));
            RuleFor(x => x.FileName)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileName"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileName"));
            RuleFor(x => x.FileType)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileType"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileType"));

            // maybe add photo later
            //RuleFor(x => x.Photo)
            //    .NotNull()
            //    .NotEmpty();
        }
    }
}
