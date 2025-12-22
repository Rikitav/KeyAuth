namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос получения глобальной переменной
    /// </summary>
    public class VarRequest : RequestBase<Responses.VarResponse>
    {
        public override string Type => "var";

        [ApiParameter("varid")]
        public string? VarId { get; set; }
    }
}

