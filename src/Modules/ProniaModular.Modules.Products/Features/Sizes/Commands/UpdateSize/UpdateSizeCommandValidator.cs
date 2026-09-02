using FluentValidation;
using ProniaModular.Modules.Products.Features.Sizes.Commands.UpdateSize;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.UpdateSize
{
    public class UpdateSizeCommandValidator : AbstractValidator<UpdateSizeCommand>
    {
        public UpdateSizeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Size ID is required.")
                .GreaterThan(0)
                .WithMessage("Size ID must be valid.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Size name is required.")
                .MaximumLength(255)
                .WithMessage("Size name must not exceed 255 characters.");
        }
    }
}
