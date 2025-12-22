using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to fetch statistics request
    /// </summary>
    public class FetchStatsResponse : ResponseBase
    {
        [JsonPropertyName("appinfo")]
        public AppDataStructure? AppData { get; set; }
    }
}

