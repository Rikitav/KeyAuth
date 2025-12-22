namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос получения переменной пользователя
    /// </summary>
    public class GetVarRequest : RequestBase<Responses.GetVarResponse>
    {
        public override string Type => "getvar";

        [ApiParameter("var")]
        public string? VarName { get; set; }
    }
}

