using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SwiftDeclaration.Infrastructure.Behaviours;
using SwiftDeclaration.Infrastructure.Repositories;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services
            .AddMemoryCache()
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>))
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(QueryCachingBehaviour<,>))
            .AddCustomServices()
            .AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IDeclarationRepository, DeclarationRepository>();
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services
            .AddSingleton<ICachingService, CachingService>()
            .AddScoped<IUnitOfWork, UnitOfWork>();
    }

}
