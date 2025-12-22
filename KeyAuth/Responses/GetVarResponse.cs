using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to get variable request
    /// </summary>
    public class GetVarResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }

        [JsonPropertyName("response")]
        public string? Value { get; set; }
    }
}

