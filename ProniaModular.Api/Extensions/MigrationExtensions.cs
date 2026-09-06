using Microsoft.EntityFrameworkCore;
using ProniaModular.Modules.Products.Data;

namespace ProniaModular.Api.Extensions
{
    public static class MigrationExtensions
    {
        public static void MigrateDatabases(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            scope.MigrateDatabase<ProductsDbContext>();
            //Ai ile bide migration elave etmedim hamsi eynidi

            
        }
        private static void MigrateDatabase<TDbcontext>(this IServiceScope scope )
            where TDbcontext: DbContext
        {
            var database = scope.ServiceProvider.GetRequiredService<TDbcontext>();
            database.Database.Migrate();
        }
    }
}
