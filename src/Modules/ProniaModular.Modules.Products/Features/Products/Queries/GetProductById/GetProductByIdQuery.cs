using MediatR;

namespace ProniaModular.Modules.Products.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(long Id) : IRequest<GetProductByIdResponse>;

    public record GetProductByIdResponse(
        long Id,
        string Name,
        decimal Price,
        string Description,
        long CategoryId,
        string CategoryName
    );
}
