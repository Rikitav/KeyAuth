using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace KeyAuth.HostingExtensions;

/// <summary>
/// Provides extensions for service container for initializing KeyAuth services
/// </summary>
public static class ServiceCollectionKeyAuthExtensions
{
    /// <summary>
    /// Adds singleton <see cref="KeyAuthClient"/> service to container from factory, with initialization dedicated service <see cref="HostedKeyAuthService"/>
    /// </summary>
    /// <param name="services"></param>
    /// <param name="factory"></param>
    /// <returns></returns>
    public static IServiceCollection AddKeyAuth(this IServiceCollection services, Func<IServiceProvider, IKeyAuthClient> factory)
    {
        services.AddSingleton(factory);
        services.AddHostedService<HostedKeyAuthService>();
        return services;
    }

    /// <summary>
    /// Adds singleton <see cref="KeyAuthClient"/> service to container from configuration section, with initialization dedicated service <see cref="HostedKeyAuthService"/>
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddKeyAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KeyAuthClientOptions>(configuration);
        services.AddSingleton<IKeyAuthClient>(KeyAuthClientDefaultFactory);
        services.AddHostedService<HostedKeyAuthService>();
        return services;
    }

    private static KeyAuthClient KeyAuthClientDefaultFactory(IServiceProvider services)
    {
        IOptions<KeyAuthClientOptions> options = services.GetRequiredService<IOptions<KeyAuthClientOptions>>();
        return new KeyAuthClient(options.Value);
    }
}
