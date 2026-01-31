using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace KeyAuth;

/// <summary>
/// Interface for KeyAuth API client
/// </summary>
public interface IKeyAuthClient
{
    /// <summary>
    /// Client options
    /// </summary>
    KeyAuthClientOptions Options { get; }

    /// <summary>
    /// Current session ID (set after successful initialization)
    /// </summary>
    string? SessionId { get; }

    /// <summary>
    /// Sets the session ID (internal method for use by extension methods)
    /// </summary>
    void SetSessionId(string sessionId);

    /// <summary>
    /// Sends an HTTP request and returns the deserialized response
    /// </summary>
    /// <typeparam name="TResponse">Response type that inherits from ResponseBase</typeparam>
    /// <param name="request">HTTP request</param>
    /// <param name="cancellationToken"></param>
    /// <returns>Deserialized response</returns>
    Task<TResponse> SendRequest<TResponse>(HttpRequestMessage request, CancellationToken cancellationToken = default) where TResponse : ResponseBase;
}

