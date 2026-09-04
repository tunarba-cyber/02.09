using MediatR;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, GetProductByIdResponse>
    {
        private readonly IAppDbContext _context;

        public GetProductByIdHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<GetProductByIdResponse> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = _context.Products
                .Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new { p, c })
                .FirstOrDefault(x => x.p.Id == request.Id && x.p.IsDeleted == 0);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with ID {request.Id} not found.");
            }

            return await Task.FromResult(new GetProductByIdResponse(
                product.p.Id,
                product.p.Name,
                product.p.Price,
                product.p.Description,
                product.p.CategoryId,
                product.c.Name
            ));
        }
    }
}