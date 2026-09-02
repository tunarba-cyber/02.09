using MediatR;

namespace ProniaModular.Modules.Products.Features.Sizes.Queries.GetAllSizes
{
    public record GetAllSizesQuery : IRequest<List<GetAllSizesResponse>>;

    public record GetAllSizesResponse(long Id, string Name);
}
