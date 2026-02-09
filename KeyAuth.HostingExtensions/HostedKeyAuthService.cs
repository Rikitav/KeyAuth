using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace KeyAuth.HostingExtensions;

/// <summary>
/// Initialization dedicated hosted service for <see cref="KeyAuthClient"/>
/// </summary>
/// <param name="client"></param>
public sealed class HostedKeyAuthService(IKeyAuthClient client) : BackgroundService
{
    /// <inheritdoc/>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await client.InitAsync(null, stoppingToken);
    }
}
