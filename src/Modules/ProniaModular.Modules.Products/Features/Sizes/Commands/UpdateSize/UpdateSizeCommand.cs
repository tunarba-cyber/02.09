using MediatR;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.UpdateSize
{
    public record UpdateSizeCommand(long Id, string Name) : IRequest<UpdateSizeResponse>;

    public record UpdateSizeResponse(long Id, string Name);
}
