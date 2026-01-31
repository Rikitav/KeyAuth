using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to get a user variable
/// </summary>
public class GetVarRequest : RequestBase<GetVarResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "getvar";

    /// <summary>
    /// The name of the variable
    /// </summary>
    [ApiParameter("var")]
    public string? VarName { get; set; }
}

