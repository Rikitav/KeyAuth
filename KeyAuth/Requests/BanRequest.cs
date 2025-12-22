namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос бана пользователя
    /// </summary>
    public class BanRequest : RequestBase<Responses.BanResponse>
    {
        public override string Type => "ban";

        [ApiParameter("reason")]
        public string? Reason { get; set; }
    }
}

