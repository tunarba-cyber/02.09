using FluentValidation;
using ProniaModular.Modules.Products.Features.Sizes.Commands.CreateSize;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.CreateSize
{
    public class CreateSizeCommandValidator : AbstractValidator<CreateSizeCommand>
    {
        public CreateSizeCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Size name is required.")
                .MaximumLength(255)
                .WithMessage("Size name must not exceed 255 characters.");
        }
    }
}
