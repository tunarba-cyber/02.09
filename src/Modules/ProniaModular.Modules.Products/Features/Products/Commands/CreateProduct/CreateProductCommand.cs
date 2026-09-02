using MediatR;

namespace ProniaModular.Modules.Products.Features.Products.Commands.CreateProduct
{
    public record CreateProductCommand(
        string Name,
        decimal Price,
        string Description,
        long CategoryId
    ) : IRequest<CreateProductResponse>;

    public record CreateProductResponse(
        long Id,
        string Name,
        decimal Price,
        string Description,
        long CategoryId
    );
}
