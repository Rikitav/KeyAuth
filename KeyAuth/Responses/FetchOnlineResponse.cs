using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a fetch online users request
/// </summary>
public class FetchOnlineResponse : ResponseBase
{
    /// <summary>
    /// A list of online users
    /// </summary>
    [JsonPropertyName("users")]
    public List<User>? Users { get; set; }
}

