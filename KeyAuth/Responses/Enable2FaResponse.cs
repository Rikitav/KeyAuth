using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to enable two-factor authentication request
    /// </summary>
    public class Enable2FaResponse : ResponseBase
    {
        [JsonPropertyName("2fa")]
        public TwoFactorData? TwoFactor { get; set; }
    }
}

