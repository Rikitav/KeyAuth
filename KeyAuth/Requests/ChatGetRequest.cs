namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос получения сообщений из чата
    /// </summary>
    public class ChatGetRequest : RequestBase<Responses.ChatGetResponse>
    {
        public override string Type => "chatget";

        [ApiParameter("channel")]
        public string? ChannelName { get; set; }
    }
}

