using FluentValidation;
using ProniaModular.Modules.Products.Features.Products.Queries.GetProductById;

namespace ProniaModular.Modules.Products.Features.Products.Queries.GetProductById
{
    public class GetProductByIdQueryValidator : AbstractValidator<GetProductByIdQuery>
    {
        public GetProductByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Product ID is required.")
                .GreaterThan(0)
                .WithMessage("Product ID must be valid.");
        }
    }
}
