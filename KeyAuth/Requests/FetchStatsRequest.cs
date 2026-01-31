using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to fetch application statistics
/// </summary>
public class FetchStatsRequest : RequestBase<FetchStatsResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "fetchStats";
}

