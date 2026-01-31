using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to recover a password
/// </summary>
public class ForgotRequest : RequestBase<ForgotResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "forgot";

    /// <summary>
    /// The username
    /// </summary>
    [ApiParameter("username")]
    public string? Username { get; set; }

    /// <summary>
    /// The email address
    /// </summary>
    [ApiParameter("email")]
    public string? Email { get; set; }
}

