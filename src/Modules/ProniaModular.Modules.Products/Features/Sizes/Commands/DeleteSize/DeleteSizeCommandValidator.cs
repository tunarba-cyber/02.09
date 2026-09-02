using FluentValidation;
using ProniaModular.Modules.Products.Features.Sizes.Commands.DeleteSize;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.DeleteSize
{
    public class DeleteSizeCommandValidator : AbstractValidator<DeleteSizeCommand>
    {
        public DeleteSizeCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Size ID is required.")
                .GreaterThan(0)
                .WithMessage("Size ID must be valid.");
        }
    }
}
