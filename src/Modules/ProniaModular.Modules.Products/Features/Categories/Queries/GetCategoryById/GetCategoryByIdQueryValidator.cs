using FluentValidation;
using ProniaModular.Modules.Products.Features.Categories.Queries.GetCategoryById;

namespace ProniaModular.Modules.Products.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQueryValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Category ID is required.")
                .GreaterThan(0)
                .WithMessage("Category ID must be valid.");
        }
    }
}
