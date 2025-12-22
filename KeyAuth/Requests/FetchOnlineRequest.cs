namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос получения списка онлайн пользователей
    /// </summary>
    public class FetchOnlineRequest : RequestBase<Responses.FetchOnlineResponse>
    {
        public override string Type => "fetchOnline";
    }
}

