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
    public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
    {
        public PortfolioUpdateValidation()
        {
            RuleFor(x => x.Title)
              .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
              .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
              .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Title", 200));

        }
    }
}
