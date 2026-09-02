using FluentValidation;
using ProniaModular.Modules.Products.Features.Categories.Commands.CreateCategory;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .MaximumLength(255)
                .WithMessage("Category name must not exceed 255 characters.");
        }
    }
}
