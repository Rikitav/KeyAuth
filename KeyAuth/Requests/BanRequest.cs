using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to ban a user
/// </summary>
public class BanRequest : RequestBase<BanResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "ban";

    /// <summary>
    /// The reason for the ban
    /// </summary>
    [ApiParameter("reason")]
    public string? Reason { get; set; }
}

