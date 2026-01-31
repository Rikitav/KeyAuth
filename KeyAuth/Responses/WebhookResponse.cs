using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a webhook request
/// </summary>
public class WebhookResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// The response from the webhook
    /// </summary>
    [JsonPropertyName("response")]
    public string? Response { get; set; }
}

