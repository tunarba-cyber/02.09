using MediatR;

namespace ProniaModular.Modules.Products.Features.Sizes.Queries.GetSizeById
{
    public record GetSizeByIdQuery(long Id) : IRequest<GetSizeByIdResponse>;

    public record GetSizeByIdResponse(long Id, string Name);
}
