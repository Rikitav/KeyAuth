using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Ответ на запрос установки переменной
    /// </summary>
    public class SetVarResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }
    }
}

