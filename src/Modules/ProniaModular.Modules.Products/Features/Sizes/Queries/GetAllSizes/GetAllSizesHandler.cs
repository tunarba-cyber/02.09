using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Sizes.Queries.GetAllSizes
{
    public class GetAllSizesHandler : IRequestHandler<GetAllSizesQuery, List<GetAllSizesResponse>>
    {
        private readonly ProductsDbContext _context;

        public GetAllSizesHandler(ProductsDbContext context)
        {
            _context = context;
        }

        public async Task<List<GetAllSizesResponse>> Handle(GetAllSizesQuery request, CancellationToken cancellationToken)
        {
            var sizes = _context.Sizes
                .Where(s => s.IsDeleted == 0)
                .Select(s => new GetAllSizesResponse(s.Id, s.Name))
                .ToList();

            return await Task.FromResult(sizes);
        }
    }
}
