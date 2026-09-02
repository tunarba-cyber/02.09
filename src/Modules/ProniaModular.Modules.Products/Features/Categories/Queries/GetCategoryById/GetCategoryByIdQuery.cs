using MediatR;

namespace ProniaModular.Modules.Products.Features.Categories.Queries.GetCategoryById
{
    public record GetCategoryByIdQuery(long Id) : IRequest<GetCategoryByIdResponse>;

    public record GetCategoryByIdResponse(long Id, string Name);
}
