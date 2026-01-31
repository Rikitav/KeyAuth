using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a chat get request
/// </summary>
public class ChatGetResponse : ResponseBase
{
    /// <summary>
    /// A list of chat messages
    /// </summary>
    [JsonPropertyName("messages")]
    public List<MessageEntity>? Messages { get; set; }
}

