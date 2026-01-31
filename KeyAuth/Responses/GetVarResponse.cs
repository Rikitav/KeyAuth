using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a get variable request
/// </summary>
public class GetVarResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// The value of the variable
    /// </summary>
    [JsonPropertyName("response")]
    public string? Value { get; set; }
}

