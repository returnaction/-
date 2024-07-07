using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ContactVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
    public class ContactAddValidation : AbstractValidator<ContactAddVM>
    {
        public ContactAddValidation()
        {
            RuleFor(x => x.Location)
                .NotNull()
                .NotEmpty()
                .MaximumLength(500);
            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(200);
            RuleFor(x => x.Call)
                .NotNull()
                .NotEmpty()
                .MaximumLength(20);
            RuleFor(x => x.Map)
                .NotNull()
                .NotEmpty();
                
        }
    }
}
