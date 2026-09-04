using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProniaModular.Modules.Products.Data;
using ProniaModular.Modules.Products.Features.Categories.Commands.CreateCategory;
using ProniaModular.Modules.Products.Features.Products.Commands.CreateProduct;

namespace ProniaModular.Modules.Products
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProductsModule(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<ProductsDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Expose the concrete DbContext through the IAppDbContext abstraction
            services.AddScoped<IAppDbContext>(sp => sp.GetRequiredService<ProductsDbContext>());

            // Register MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExtensions).Assembly));

            // Register FluentValidation
            services.AddValidatorsFromAssembly(typeof(ServiceCollectionExtensions).Assembly);

            return services;
        }
    }
}