using Microsoft.Extensions.DependencyInjection;
using ProniaModular.Modules.Users.Infrastructure;

namespace ProniaModular.Modules.Users.Application.Presentation
{
    public static class ModuleServiceRegistration
    {
        public static IServiceCollection AddUsersModule(this IServiceCollection services, string connectionString)
        {
            services.AddApplicationServices();
            //services.AddInfrastructureServices(connectionString);
            return services;
        }

        // If this doesn't exist yet elsewhere, add it here:
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // e.g. register MediatR handlers, validators, mappers, etc.
            return services;
        }
    }
}