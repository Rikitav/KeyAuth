using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to webhook request
    /// </summary>
    public class WebhookResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }

        [JsonPropertyName("response")]
        public string? Response { get; set; }
    }
}

