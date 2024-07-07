using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.TestimonialVM;
using Сантехник.ServiceLayer.Messages.WebApplication;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.TestimonialValidation
{
    public class TestimonialAddValidation : AbstractValidator<TestimonialAddVM>
    {
        public TestimonialAddValidation()
        {
            RuleFor(x => x.Comment)
             .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
             .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
             .MaximumLength(5000).WithMessage(ValidationMessages.MaximumCharacterAllowance("Comment", 5000));
            RuleFor(x => x.FullName)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Full Name"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Full Name"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharacterAllowance("Full Name", 200));
            RuleFor(x => x.Title)
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(200);


            // maybe add photo later
            //RuleFor(x => x.Photo)
            //    .NotNull()
            //    .NotEmpty();
        }
    }
}
