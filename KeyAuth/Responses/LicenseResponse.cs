using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a license authentication request
/// </summary>
public class LicenseResponse : ResponseBase
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

