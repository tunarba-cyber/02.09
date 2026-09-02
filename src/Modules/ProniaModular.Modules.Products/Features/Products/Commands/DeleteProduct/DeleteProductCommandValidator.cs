using FluentValidation;
using ProniaModular.Modules.Products.Features.Products.Commands.DeleteProduct;

namespace ProniaModular.Modules.Products.Features.Products.Commands.DeleteProduct
{
    public class DeleteProductCommandValidator : AbstractValidator<DeleteProductCommand>
    {
        public DeleteProductCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required.")
                .GreaterThan(0)
                .WithMessage("Product ID must be valid.");
        }
    }
}
