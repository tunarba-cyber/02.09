using Microsoft.EntityFrameworkCore;
using ProniaModular.Modules.Products.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaModular.Modules.Products.Data
{
    internal static class GlobalQueryFilter
    {
         internal static void ApplyGlobalFilters( this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyGlobalQueryFilter<Product>();
            modelBuilder.ApplyGlobalQueryFilter<Size>();
            modelBuilder.ApplyGlobalQueryFilter<Category>();
        }
        private static ModelBuilder ApplyGlobalQueryFilter<TEntity>(this ModelBuilder modelBuilder) where TEntity : BaseEntity
        {
            modelBuilder.Entity<TEntity>().HasQueryFilter(e => !e.IsDeleted);
            return modelBuilder;
        }
    }
}
