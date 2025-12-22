using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Ответ на запрос проверки на черный список
    /// </summary>
    public class CheckBlackResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }
    }
}

