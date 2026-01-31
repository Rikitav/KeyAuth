using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to logout
/// </summary>
public class LogoutRequest : RequestBase<LogoutResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "logout";
}

