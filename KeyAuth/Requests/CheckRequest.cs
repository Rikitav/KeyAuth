namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос проверки сессии
    /// </summary>
    public class CheckRequest : RequestBase<Responses.CheckResponse>
    {
        public override string Type => "check";
    }
}

