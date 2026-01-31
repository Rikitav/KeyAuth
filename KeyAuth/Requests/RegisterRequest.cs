using KeyAuth.Responses;
using System.Collections.Specialized;
using System.Security.Principal;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to register a new user
/// </summary>
public class RegisterRequest : RequestBase<RegisterResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "register";

    /// <summary>
    /// The username
    /// </summary>
    [ApiParameter("username")]
    public string? Username { get; set; }

    /// <summary>
    /// The password
    /// </summary>
    [ApiParameter("pass")]
    public string? Password { get; set; }

    /// <summary>
    /// The license key
    /// </summary>
    [ApiParameter("key")]
    public string? Key { get; set; }

    /// <summary>
    /// The email address
    /// </summary>
    [ApiParameter("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Gets additional parameters for the request
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

