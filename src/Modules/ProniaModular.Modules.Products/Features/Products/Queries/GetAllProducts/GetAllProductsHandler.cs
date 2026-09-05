using MediatR;
using Microsoft.EntityFrameworkCore;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Modules.Products.Features.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, PagedResult<GetAllProductsResponse>>
    {
        private readonly IAppDbContext _context;

        public GetAllProductsHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<PagedResult<GetAllProductsResponse>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Products
                .Join(_context.Categories, p => p.CategoryId, c => c.Id, (p, c) => new { p, c })
                .AsQueryable();

            // Soft-delete filter
            if (!request.IncludeDeleted)
            {
                query = query.Where(x => !x.p.IsDeleted);
            }

            // Search filter (name or description)
            if (!string.IsNullOrWhiteSpace(request.Search))
            {
                var search = request.Search.Trim();
                query = query.Where(x =>
                    EF.Functions.Like(x.p.Name, $"%{search}%") ||
                    EF.Functions.Like(x.p.Description, $"%{search}%"));
            }

            // Price range filters
            if (request.MinPrice.HasValue)
            {
                query = query.Where(x => x.p.Price >= request.MinPrice.Value);
            }

            if (request.MaxPrice.HasValue)
            {
                query = query.Where(x => x.p.Price <= request.MaxPrice.Value);
            }

            // Sorting
            query = request.SortBy?.ToLower() switch
            {
                "name" => request.IsDescending
                    ? query.OrderByDescending(x => x.p.Name)
                    : query.OrderBy(x => x.p.Name),
                "price" => request.IsDescending
                    ? query.OrderByDescending(x => x.p.Price)
                    : query.OrderBy(x => x.p.Price),
                "category" => request.IsDescending
                    ? query.OrderByDescending(x => x.c.Name)
                    : query.OrderBy(x => x.c.Name),
                _ => request.IsDescending
                    ? query.OrderByDescending(x => x.p.Id)
                    : query.OrderBy(x => x.p.Id),
            };

            var totalCount = await query.CountAsync(cancellationToken);

            var page = request.Page < 1 ? 1 : request.Page;
            var pageSize = request.PageSize < 1 ? 10 : request.PageSize;

            var items = await query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(x => new GetAllProductsResponse(
                    x.p.Id,
                    x.p.Name,
                    x.p.Price,
                    x.p.Description,
                    x.p.CategoryId,
                    x.c.Name,
                    x.p.IsDeleted
                ))
                .ToListAsync(cancellationToken);

            var totalPages = (int)Math.Ceiling(totalCount / (double)pageSize);

            return new PagedResult<GetAllProductsResponse>(items, page, pageSize, totalCount, totalPages);
        }
    }
}