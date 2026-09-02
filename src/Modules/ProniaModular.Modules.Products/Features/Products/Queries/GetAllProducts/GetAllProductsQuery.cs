using MediatR;

namespace ProniaModular.Modules.Products.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery : IRequest<List<GetAllProductsResponse>>;

    public record GetAllProductsResponse(
        long Id,
        string Name,
        decimal Price,
        string Description,
        long CategoryId,
        string CategoryName
    );
}
