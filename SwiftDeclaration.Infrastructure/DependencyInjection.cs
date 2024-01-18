using Microsoft.Extensions.DependencyInjection;
using SwiftDeclaration.Infrastructure.Repositories;
using SwiftDeclaration.Infrastructure.Repositories.Interfaces;
using SwiftDeclaration.Infrastructure.Services;
using SwiftDeclaration.Infrastructure.Services.Interfaces;

namespace SwiftDeclaration.Infrastructure;

public static class DependencyInjection
{

    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        return services.AddRepositories();
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        return services
            .AddScoped<IUnitOfWork, UnitOfWork>()
            .AddScoped<IDeclarationRepository, DeclarationRepository>();
    }

}
