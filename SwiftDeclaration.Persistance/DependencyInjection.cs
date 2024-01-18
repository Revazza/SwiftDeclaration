using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SwiftDeclaration.Persistance.Context;

namespace SwiftDeclaration.Persistance;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistance(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {

        return services
            .ConfigureDbContext(configuration);
    }

    private static IServiceCollection ConfigureDbContext(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {

        return services.AddDbContext<SwiftDeclarationDbContext>(opt =>
        {
            opt.UseSqlServer(configuration.GetConnectionString(SwiftDeclarationDbContext.SectionName));
        });
    }

}
