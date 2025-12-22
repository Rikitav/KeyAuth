using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to authentication request
    /// </summary>
    public class LoginResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }

        [JsonPropertyName("info")]
        public UserDataStructure? UserData { get; set; }
    }
}

