using KeyAuth.Responses;
using KeyAuth.Utilities;
using System.Collections.Specialized;
using System.Diagnostics;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to initialize the application
/// </summary>
public class InitRequest : RequestBase<InitResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "init";

    /// <summary>
    /// The name of the application
    /// </summary>
    [ApiParameter("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The owner ID of the application
    /// </summary>
    [ApiParameter("ownerid")]
    public string? OwnerId { get; set; }

    /// <summary>
    /// The version of the application
    /// </summary>
    [ApiParameter("ver")]
    public string? Version { get; set; }

    /// <summary>
    /// The path to the token file
    /// </summary>
    [IgnoreApiParameter]
    public string? TokenPath { get; set; }

    /// <summary>
    /// Gets additional parameters for the request
    /// </summary>
    /// <param name="sessionId">The session ID</param>
    /// <param name="name">The application name</param>
    /// <param name="ownerId">The owner ID</param>
    /// <returns>A collection of additional parameters</returns>
    protected override NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
    {
        var parameters = new NameValueCollection
        {
            ["hash"] = KeyAuthHelper.Checksum(Process.GetCurrentProcess().MainModule.FileName)
        };

        if (!string.IsNullOrEmpty(TokenPath))
        {
            parameters.Add("token", System.IO.File.ReadAllText(TokenPath));
            parameters.Add("thash", KeyAuthHelper.TokenHash(TokenPath));
        }

        return parameters;
    }
}

