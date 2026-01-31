using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to an initialization request
/// </summary>
public class InitResponse : ResponseBase
{
    /// <summary>
    /// The download link for the application
    /// </summary>
    [JsonPropertyName("download")]
    public string? DownloadLink { get; set; }

    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }
}

