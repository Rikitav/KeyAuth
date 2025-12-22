using System.Net.Http;
using System.Threading.Tasks;

namespace KeyAuth
{
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
        /// Sends an HTTP request and returns the deserialized response
        /// </summary>
        /// <typeparam name="TResponse">Response type that inherits from ResponseBase</typeparam>
        /// <param name="request">HTTP request</param>
        /// <returns>Deserialized response</returns>
        Task<TResponse> SendRequest<TResponse>(HttpRequestMessage request) where TResponse : ResponseBase;
    }
}

