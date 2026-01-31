using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a global variable request
/// </summary>
public class VarResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// The value of the variable
    /// </summary>
    public string? Value => Message;
}

