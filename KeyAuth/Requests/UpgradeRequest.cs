using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to upgrade a user's subscription
/// </summary>
public class UpgradeRequest : RequestBase<UpgradeResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "upgrade";

    /// <summary>
    /// The username to upgrade
    /// </summary>
    [ApiParameter("username")]
    public string? Username { get; set; }

    /// <summary>
    /// The license key to use for the upgrade
    /// </summary>
    [ApiParameter("key")]
    public string? Key { get; set; }
}

