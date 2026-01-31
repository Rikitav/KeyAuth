using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to get a global variable
/// </summary>
public class VarRequest : RequestBase<VarResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "var";

    /// <summary>
    /// The ID of the variable
    /// </summary>
    [ApiParameter("varid")]
    public string? VarId { get; set; }
}

