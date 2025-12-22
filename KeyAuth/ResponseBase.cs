using System.Text.Json.Serialization;

namespace KeyAuth
{
    /// <summary>
    /// Base class for all KeyAuth API responses
    /// </summary>
    public abstract class ResponseBase
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; }

        [JsonPropertyName("newSession")]
        public bool NewSession { get; set; }

        [JsonPropertyName("sessionid")]
        public string? SessionId { get; set; }

        [JsonPropertyName("code")]
        public int? Code { get; set; }

        [JsonPropertyName("nonce")]
        public string? Nonce { get; set; }
    }
}

