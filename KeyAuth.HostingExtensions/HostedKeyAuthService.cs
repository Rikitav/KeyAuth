using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace KeyAuth.HostingExtensions;

public sealed class HostedKeyAuthService(IKeyAuthClient client) : IHostedService
{
    /// <inheritdoc/>
    public Task StartAsync(CancellationToken cancellationToken)
    {
        _ = InternalStartAsync(cancellationToken);
        return Task.CompletedTask;
    }

    /// <inheritdoc/>
    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    private async Task InternalStartAsync(CancellationToken cancellationToken)
    {
        await client.InitAsync(null, cancellationToken);
    }
}
