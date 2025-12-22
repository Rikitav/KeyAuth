using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Ответ на запрос проверки сессии
    /// </summary>
    public class CheckResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }
    }
}

