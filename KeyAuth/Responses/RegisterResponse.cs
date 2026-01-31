using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a registration request
/// </summary>
public class RegisterResponse : ResponseBase
{
    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [JsonPropertyName("ownerid")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// The user data
    /// </summary>
    [JsonPropertyName("info")]
    public UserDataStructure? UserData { get; set; }
}

