namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос восстановления пароля
    /// </summary>
    public class ForgotRequest : RequestBase<Responses.ForgotResponse>
    {
        public override string Type => "forgot";

        [ApiParameter("username")]
        public string? Username { get; set; }

        [ApiParameter("email")]
        public string? Email { get; set; }
    }
}

