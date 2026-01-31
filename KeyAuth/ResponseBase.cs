using System.Text.Json.Serialization;

namespace KeyAuth;

/// <summary>
/// Base class for all KeyAuth API responses
/// </summary>
public abstract class ResponseBase
{
    /// <summary>
    /// Indicates if the request was successful
    /// </summary>
    [JsonPropertyName("success")]
    public bool Success { get; set; }

    /// <summary>
    /// The response message
    /// </summary>
    [JsonPropertyName("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Indicates if a new session was created
    /// </summary>
    [JsonPropertyName("newSession")]
    public bool NewSession { get; set; }

    /// <summary>
    /// The session ID
    /// </summary>
    [JsonPropertyName("sessionid")]
    public string? SessionId { get; set; }

    /// <summary>
    /// The response code
    /// </summary>
    [JsonPropertyName("code")]
    public int? Code { get; set; }

    /// <summary>
    /// A random nonce
    /// </summary>
    [JsonPropertyName("nonce")]
    public string? Nonce { get; set; }
}

