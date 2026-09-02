using MediatR;

namespace ProniaModular.Modules.Products.Features.Products.Commands.DeleteProduct
{
    public record DeleteProductCommand(long Id) : IRequest<DeleteProductResponse>;

    public record DeleteProductResponse(bool Success, string Message);
}
