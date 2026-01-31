using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to change a username
/// </summary>
public class ChangeUsernameRequest : RequestBase<ChangeUsernameResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "changeUsername";

    /// <summary>
    /// The new username
    /// </summary>
    [ApiParameter("newUsername")]
    public string? NewUsername { get; set; }
}

