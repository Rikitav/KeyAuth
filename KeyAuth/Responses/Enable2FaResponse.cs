using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to an enable 2FA request
/// </summary>
public class Enable2FaResponse : ResponseBase
{
    /// <summary>
    /// The two-factor authentication data
    /// </summary>
    [JsonPropertyName("2fa")]
    public TwoFactorData? TwoFactor { get; set; }
}

