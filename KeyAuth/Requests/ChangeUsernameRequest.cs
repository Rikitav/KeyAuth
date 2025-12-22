namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос изменения имени пользователя
    /// </summary>
    public class ChangeUsernameRequest : RequestBase<Responses.ChangeUsernameResponse>
    {
        public override string Type => "changeUsername";

        [ApiParameter("newUsername")]
        public string? NewUsername { get; set; }
    }
}

