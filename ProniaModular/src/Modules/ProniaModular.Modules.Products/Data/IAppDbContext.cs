using Microsoft.EntityFrameworkCore;
using ProniaModular.Modules.Products.Entities;

namespace ProniaModular.Modules.Products.Data
{
    public interface IAppDbContext
    {
        DbSet<Product> Products { get; }
        DbSet<Category> Categories { get; }
        DbSet<Size> Sizes { get; }
        DbSet<ProductSize> ProductSizes { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
