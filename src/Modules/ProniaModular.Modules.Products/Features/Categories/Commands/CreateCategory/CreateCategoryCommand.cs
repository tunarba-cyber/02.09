using MediatR;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.CreateCategory
{
    public record CreateCategoryCommand(string Name) : IRequest<CreateCategoryResponse>;

    public record CreateCategoryResponse(long Id, string Name);
}
