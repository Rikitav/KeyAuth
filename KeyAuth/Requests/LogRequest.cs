using KeyAuth.Responses;
using System.Collections.Specialized;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to log an event
/// </summary>
public class LogRequest : RequestBase<LogResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "log";

    /// <summary>
    /// The message to log
    /// </summary>
    [ApiParameter("message")]
    public string? Message { get; set; }

    /// <summary>
    /// Gets additional parameters for the request
    /// </summary>
    /// <param name="sessionId">The session ID</param>
    /// <param name="name">The application name</param>
    /// <param name="ownerId">The owner ID</param>
    /// <returns>A collection of additional parameters</returns>
    protected override NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
    {
        return new NameValueCollection
        {
            ["pcuser"] = System.Environment.UserName
        };
    }
}

