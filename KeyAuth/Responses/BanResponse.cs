using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a ban request
/// </summary>
public class BanResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }
}

