using MediatR;

namespace ProniaModular.Modules.Products.Features.Products.Queries.GetAllProducts
{
    public record GetAllProductsQuery(
        bool IncludeDeleted = false,
        string? Search = null,
        decimal? MinPrice = null,
        decimal? MaxPrice = null,
        string? SortBy = null,
        bool IsDescending = false,
        int Page = 1,
        int PageSize = 10
    ) : IRequest<PagedResult<GetAllProductsResponse>>;

    public record GetAllProductsResponse(
        long Id,
        string Name,
        decimal Price,
        string Description,
        long CategoryId,
        string CategoryName,
        bool IsArchived
    );

    public record PagedResult<T>(
        List<T> Items,
        int Page,
        int PageSize,
        int TotalCount,
        int TotalPages
    );
}