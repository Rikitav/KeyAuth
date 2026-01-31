using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to get chat messages
/// </summary>
public class ChatGetRequest : RequestBase<ChatGetResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "chatget";

    /// <summary>
    /// The name of the channel
    /// </summary>
    [ApiParameter("channel")]
    public string? ChannelName { get; set; }
}

