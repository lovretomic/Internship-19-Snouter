using Microsoft.Extensions.DependencyInjection;
using Snouter.Application.Database;
using Snouter.Application.Repositories;

namespace Snouter.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        services.AddSingleton<ICategoryRepository, CategoryRepository>();
        services.AddSingleton<ISubcategoryRepository, SubcategoryRepository>();
        services.AddSingleton<IItemRepository, ItemRepository>();
        return services;
    }

    public static IServiceCollection AddDatabase(this IServiceCollection services, string connectionString)
    {
        services.AddSingleton<IDbConnectionFactory>(_ => new NpgsqlConnectionFactory(connectionString));
        services.AddSingleton<DbInitializer>();
        return services;
    }
}