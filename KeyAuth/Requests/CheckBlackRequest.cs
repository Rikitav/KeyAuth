using KeyAuth.Responses;
using System.Collections.Specialized;
using System.Security.Principal;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to check if the current user is blacklisted
/// </summary>
public class CheckBlackRequest : RequestBase<CheckBlackResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "checkblacklist";

    /// <summary>
    /// Gets the additional parameters for the request
    /// </summary>
    /// <param name="sessionId">The session ID</param>
    /// <param name="name">The application name</param>
    /// <param name="ownerId">The owner ID</param>
    /// <returns>A collection of additional parameters</returns>
    protected override NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
    {
        string? hwid = WindowsIdentity.GetCurrent().User?.Value;
        return new NameValueCollection
        {
            ["hwid"] = hwid ?? string.Empty
        };
    }
}

