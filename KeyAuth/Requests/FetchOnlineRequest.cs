using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to fetch online users
/// </summary>
public class FetchOnlineRequest : RequestBase<FetchOnlineResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "fetchOnline";
}

