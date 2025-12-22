namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос вызова вебхука
    /// </summary>
    public class WebhookRequest : RequestBase<Responses.WebhookResponse>
    {
        public override string Type => "webhook";

        [ApiParameter("webid")]
        public string? WebId { get; set; }

        [ApiParameter("params")]
        public string? Params { get; set; }

        [ApiParameter("body")]
        public string? Body { get; set; }

        [ApiParameter("conttype")]
        public string? ContentType { get; set; }
    }
}

