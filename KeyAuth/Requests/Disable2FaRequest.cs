using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to disable two-factor authentication
/// </summary>
public class Disable2FaRequest : RequestBase<Disable2FaResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "2fadisable";

    /// <summary>
    /// The 2FA code
    /// </summary>
    [ApiParameter("code")]
    public string? Code { get; set; }
}

