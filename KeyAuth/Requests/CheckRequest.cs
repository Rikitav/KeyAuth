using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to check the current session
/// </summary>
public class CheckRequest : RequestBase<CheckResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "check";
}

