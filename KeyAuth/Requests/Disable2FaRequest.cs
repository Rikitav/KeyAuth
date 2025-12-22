namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос отключения двухфакторной аутентификации
    /// </summary>
    public class Disable2FaRequest : RequestBase<Responses.Disable2FaResponse>
    {
        public override string Type => "2fadisable";

        [ApiParameter("code")]
        public string? Code { get; set; }
    }
}

