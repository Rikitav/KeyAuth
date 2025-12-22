using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to initialization request
    /// </summary>
    public class InitResponse : ResponseBase
    {
        [JsonPropertyName("download")]
        public string? DownloadLink { get; set; }

        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }
    }
}

