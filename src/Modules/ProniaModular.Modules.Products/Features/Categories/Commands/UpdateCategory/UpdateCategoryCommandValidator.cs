using FluentValidation;
using ProniaModular.Modules.Products.Features.Categories.Commands.UpdateCategory;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Category ID is required.")
                .GreaterThan(0)
                .WithMessage("Category ID must be valid.");

            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .MaximumLength(255)
                .WithMessage("Category name must not exceed 255 characters.");
        }
    }
}
