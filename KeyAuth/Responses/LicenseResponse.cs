using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to license authentication request
    /// </summary>
    public class LicenseResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }

        [JsonPropertyName("info")]
        public UserDataStructure? UserData { get; set; }
    }
}

