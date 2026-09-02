using MediatR;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.DeleteSize
{
    public record DeleteSizeCommand(long Id) : IRequest<DeleteSizeResponse>;

    public record DeleteSizeResponse(bool Success, string Message);
}
