using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Ответ на запрос обновления подписки
    /// </summary>
    public class UpgradeResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }
    }
}

