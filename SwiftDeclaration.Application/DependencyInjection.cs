using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.Extensions.DependencyInjection;
using SwiftDeclaration.Application.Services;
using SwiftDeclaration.Application.Services.Interfaces;
using System.Reflection;

namespace SwiftDeclaration.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services
            .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly())
            .AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly())
            )
            .AddMappingsConfigurations()
            .AddCustomServices();
    }

    private static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        return services
            .AddTransient<IImageProcessingService, ImageProcessingService>();
    }

    private static IServiceCollection AddMappingsConfigurations(this IServiceCollection services)
    {
        var config = TypeAdapterConfig.GlobalSettings;
        config.Scan(Assembly.GetExecutingAssembly());

        services.AddSingleton(config);
        services.AddScoped<IMapper, Mapper>();

        return services;
    }

}
