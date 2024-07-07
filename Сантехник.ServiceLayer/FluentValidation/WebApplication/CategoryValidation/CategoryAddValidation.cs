using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.CategoryVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.CategoryValidation
{
    public class CategoryAddValidation : AbstractValidator<CategoryAddVM>
    {
        public CategoryAddValidation()
        {
            RuleFor(x => x.Name)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Name"))
                .MaximumLength(50).WithMessage(ValidationMessages.MaximumCharacterAllowance("Name", 50));
        }
    }
}
