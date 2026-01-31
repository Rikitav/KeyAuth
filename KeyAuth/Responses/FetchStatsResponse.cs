using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a fetch statistics request
/// </summary>
public class FetchStatsResponse : ResponseBase
{
    /// <summary>
    /// The application data
    /// </summary>
    [JsonPropertyName("appinfo")]
    public AppDataStructure? AppData { get; set; }
}

