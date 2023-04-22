using Microsoft.Extensions.DependencyInjection;
using Snouter.Application.Repositories;

namespace Snouter.Application;

public static class ApplicationServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddSingleton<IUserRepository, UserRepository>();
        return services;
    }
}