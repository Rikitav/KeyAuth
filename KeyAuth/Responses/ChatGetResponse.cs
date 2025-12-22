using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to chat messages request
    /// </summary>
    public class ChatGetResponse : ResponseBase
    {
        [JsonPropertyName("messages")]
        public List<MessageEntity>? Messages { get; set; }
    }
}

