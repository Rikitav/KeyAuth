namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос выхода из системы
    /// </summary>
    public class LogoutRequest : RequestBase<Responses.LogoutResponse>
    {
        public override string Type => "logout";
    }
}

