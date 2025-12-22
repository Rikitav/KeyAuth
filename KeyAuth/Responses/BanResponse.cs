using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Ответ на запрос бана пользователя
    /// </summary>
    public class BanResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }
    }
}

