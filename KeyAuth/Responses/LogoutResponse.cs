using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a logout request
/// </summary>
public class LogoutResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }
}

