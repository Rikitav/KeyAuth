using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to send a chat message
/// </summary>
public class ChatSendRequest : RequestBase<ChatSendResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "chatsend";

    /// <summary>
    /// The message to send
    /// </summary>
    [ApiParameter("message")]
    public string? Message { get; set; }

    /// <summary>
    /// The name of the channel
    /// </summary>
    [ApiParameter("channel")]
    public string? ChannelName { get; set; }
}

