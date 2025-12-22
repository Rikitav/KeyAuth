namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос установки переменной пользователя
    /// </summary>
    public class SetVarRequest : RequestBase<Responses.SetVarResponse>
    {
        public override string Type => "setvar";

        [ApiParameter("var")]
        public string? VarName { get; set; }

        [ApiParameter("data")]
        public string? Data { get; set; }
    }
}

