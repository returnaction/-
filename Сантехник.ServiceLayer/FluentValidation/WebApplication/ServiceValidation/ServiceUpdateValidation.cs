using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сантехник.EntityLayer.WebApplication.ViewModels.ServiceVM;

namespace Сантехник.ServiceLayer.FluentValidation.WebApplication.ServiceValidation
{
    public class ServiceUpdateValidation : AbstractValidator<ServiceUpdateVM>
    {
        public ServiceUpdateValidation()
        {
            RuleFor(x => x.Name)
              .NotNull()
              .NotEmpty()
              .MaximumLength(200);
            RuleFor(x => x.Description)
                .NotNull()
                .NotEmpty()
                .MaximumLength(5000);

            // For Icon do maybe later when realize how to manage it
        }
    }
}
