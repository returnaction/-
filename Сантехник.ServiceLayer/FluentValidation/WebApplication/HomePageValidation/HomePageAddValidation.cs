using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.HomePageVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.HomePageValidation
{
    public class HomePageAddValidation : AbstractValidator<HomePageAddVM>
    {
        public HomePageAddValidation()
        {
            RuleFor(x => x.Header)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Header"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Header"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Header", 5000));
            RuleFor(x => x.Description)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .MaximumLength(5000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Description", 5000));
            RuleFor(x => x.VideoLink)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("VideoLink"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("VideoLink"));
        }
    }
}
