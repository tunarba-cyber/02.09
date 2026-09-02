using MediatR;

namespace ProniaModular.Modules.Products.Features.Sizes.Commands.CreateSize
{
    public record CreateSizeCommand(string Name) : IRequest<CreateSizeResponse>;

    public record CreateSizeResponse(long Id, string Name);
}
