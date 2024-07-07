using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.AboutVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.AboutValidation
{
    public class AboutUpdateValidation : AbstractValidator<AboutUpdateVM>
    {
        public AboutUpdateValidation()
        {
            RuleFor(x => x.Header)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Header"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Header"))
                .MaximumLength(5000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Header", 5000));
            RuleFor(x => x.Description)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .MaximumLength(5000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Header", 5000));
            RuleFor(x => x.Clients)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Client"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Client"))
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GreaterThenMessage("Client", 0));
            RuleFor(x => x.Projects)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Project"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Project"))
                .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GreaterThenMessage("Project", 0));
            RuleFor(x => x.HoursOfSupport)
               .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Hours Of Support"))
               .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Hours Of Support"))
               .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GreaterThenMessage("Hours Of Support", 0));
            RuleFor(x => x.HardWorkers)
               .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Hard Workers"))
               .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Har dWorkers"))
               .GreaterThanOrEqualTo(0).WithMessage(ValidationMessages.GreaterThenMessage("Hard Workers", 0));
        }
    }
}
