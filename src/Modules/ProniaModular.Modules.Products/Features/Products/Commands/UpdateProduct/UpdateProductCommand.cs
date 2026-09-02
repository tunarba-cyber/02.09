using MediatR;

namespace ProniaModular.Modules.Products.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand(
        long Id,
        string Name,
        decimal Price,
        string Description,
        long CategoryId
    ) : IRequest<UpdateProductResponse>;

    public record UpdateProductResponse(
        long Id,
        string Name,
        decimal Price,
        string Description,
        long CategoryId
    );
}
