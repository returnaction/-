using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.Identity.ViewModels;
using Сантехник.ServiceLayer.Messages.Identity;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.Identity
{
    public class ResetPasswordValidation : AbstractValidator<ResetPasswordVM>
    {
        public ResetPasswordValidation()
        {
            RuleFor(x => x.Password)
               .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Password"))
               .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Password"));
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("ConfirmPassword"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("ConfirmPassword"))
                .Equal(x => x.Password).WithMessage(IdentityMessages.ComparePassword());
        }
    }
}
