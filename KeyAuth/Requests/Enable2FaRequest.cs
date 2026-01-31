using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to enable two-factor authentication
/// </summary>
public class Enable2FaRequest : RequestBase<Enable2FaResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "2faenable";

    /// <summary>
    /// The 2FA code
    /// </summary>
    [ApiParameter("code")]
    public string? Code { get; set; }
}

