using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to fetch online users request
    /// </summary>
    public class FetchOnlineResponse : ResponseBase
    {
        [JsonPropertyName("users")]
        public List<User>? Users { get; set; }
    }
}

