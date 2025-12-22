namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос обновления подписки
    /// </summary>
    public class UpgradeRequest : RequestBase<Responses.UpgradeResponse>
    {
        public override string Type => "upgrade";

        [ApiParameter("username")]
        public string? Username { get; set; }

        [ApiParameter("key")]
        public string? Key { get; set; }
    }
}

