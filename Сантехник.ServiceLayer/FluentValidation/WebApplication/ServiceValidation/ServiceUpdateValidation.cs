using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ServiceVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
    public class ServiceUpdateValidation : AbstractValidator<ServiceUpdateVM>
    {
        public ServiceUpdateValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Name", 200));
            RuleFor(x => x.Description)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Description"))
                .MaximumLength(5000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Description", 5000));

            // For Icon do maybe later when realize how to manage it
        }
    }
}
