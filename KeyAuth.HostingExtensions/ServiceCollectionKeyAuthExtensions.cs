using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace KeyAuth.HostingExtensions;

public static class ServiceCollectionKeyAuthExtensions
{
    public static IServiceCollection AddKeyAuth(this IServiceCollection services, Func<IServiceProvider, IKeyAuthClient> factory)
    {
        services.AddSingleton(factory);
        services.AddHostedService<HostedKeyAuthService>();
        return services;
    }

    public static IServiceCollection AddKeyAuth(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KeyAuthClientOptions>(configuration);
        services.AddSingleton<IKeyAuthClient>(KeyAuthClientFactory);
        services.AddHostedService<HostedKeyAuthService>();
        return services;
    }

    private static KeyAuthClient KeyAuthClientFactory(IServiceProvider services)
    {
        IOptions<KeyAuthClientOptions> options = services.GetRequiredService<IOptions<KeyAuthClientOptions>>();
        return new KeyAuthClient(options.Value);
    }
}
