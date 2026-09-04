using Microsoft.EntityFrameworkCore;
using ProniaModular.Modules.Products.Entities;

namespace ProniaModular.Modules.Products.Data
{
    /// <summary>
    /// Abstraction over the Products module's EF Core DbContext.
    /// Handlers depend on this interface instead of the concrete
    /// ProductsDbContext so they stay testable/mockable.
    /// </summary>
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        DbSet<Size> Sizes { get; }
        DbSet<ProductSize> ProductSizes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}