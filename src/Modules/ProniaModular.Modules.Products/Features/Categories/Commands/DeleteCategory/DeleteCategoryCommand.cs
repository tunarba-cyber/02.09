using MediatR;

namespace ProniaModular.Modules.Products.Features.Categories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(long Id) : IRequest<DeleteCategoryResponse>;

    public record DeleteCategoryResponse(bool Success, string Message);
}
