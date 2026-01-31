using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a set variable request
/// </summary>
public class SetVarResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }
}

