using FluentValidation;
using ProniaModular.Modules.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Validators
{
    public class SizeValidator : AbstractValidator<Size>
    {
        public SizeValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Size name is required.")
                .MaximumLength(255)
                .WithMessage("Size name must not exceed 255 characters.");
        }
    }
}
