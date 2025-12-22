using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to registration request
    /// </summary>
    public class RegisterResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }

        [JsonPropertyName("info")]
        public UserDataStructure? UserData { get; set; }
    }
}

