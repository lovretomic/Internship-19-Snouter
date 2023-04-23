using Microsoft.Extensions.DependencyInjection;
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
}