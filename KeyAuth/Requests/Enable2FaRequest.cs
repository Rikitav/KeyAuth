namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос включения двухфакторной аутентификации
    /// </summary>
    public class Enable2FaRequest : RequestBase<Responses.Enable2FaResponse>
    {
        public override string Type => "2faenable";

        [ApiParameter("code")]
        public string? Code { get; set; }
    }
}

