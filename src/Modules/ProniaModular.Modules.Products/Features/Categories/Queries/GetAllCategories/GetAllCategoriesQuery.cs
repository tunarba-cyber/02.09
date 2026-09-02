using MediatR;

namespace ProniaModular.Modules.Products.Features.Categories.Queries.GetAllCategories
{
    public record GetAllCategoriesQuery : IRequest<List<GetAllCategoriesResponse>>;

    public record GetAllCategoriesResponse(long Id, string Name);
}
