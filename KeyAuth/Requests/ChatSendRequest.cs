namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос отправки сообщения в чат
    /// </summary>
    public class ChatSendRequest : RequestBase<Responses.ChatSendResponse>
    {
        public override string Type => "chatsend";

        [ApiParameter("message")]
        public string? Message { get; set; }

        [ApiParameter("channel")]
        public string? ChannelName { get; set; }
    }
}

