using MediatR;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand(long Id, string Name) : IRequest<UpdateCategoryResponse>;

    public record UpdateCategoryResponse(long Id, string Name);
}
