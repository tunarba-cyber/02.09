using FluentValidation;
using ProniaModular.Modules.Products.Features.Sizes.Queries.GetSizeById;

namespace ProniaModular.Modules.Products.Features.Sizes.Queries.GetSizeById
{
    public class GetSizeByIdQueryValidator : AbstractValidator<GetSizeByIdQuery>
    {
        public GetSizeByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Size ID is required.")
                .GreaterThan(0)
                .WithMessage("Size ID must be valid.");
        }
    }
}
