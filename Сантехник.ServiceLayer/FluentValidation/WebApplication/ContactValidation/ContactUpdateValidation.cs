using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
    public class ContactUpdateValidation : AbstractValidator<ContactUpdateVM>
    {
        public ContactUpdateValidation()
        {
            RuleFor(x => x.Location)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Header"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Header"))
                .MaximumLength(500).WithMessage(ValidationMessages.MaximumCharacterAllowance("Header", 500));
            RuleFor(x => x.Email)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Email", 200));
            RuleFor(x => x.Call)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Call"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Call"))
                .MaximumLength(20).WithMessage(ValidationMessages.MaximumCharacterAllowance("Call", 20));
            RuleFor(x => x.Map)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Map"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Map"));
        }
    }
}
