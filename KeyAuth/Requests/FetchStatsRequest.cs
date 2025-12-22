namespace KeyAuth.Requests
{
    /// <summary>
    /// Запрос получения статистики приложения
    /// </summary>
    public class FetchStatsRequest : RequestBase<Responses.FetchStatsResponse>
    {
        public override string Type => "fetchStats";
    }
}

