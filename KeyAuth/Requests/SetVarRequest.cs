using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to set a user variable
/// </summary>
public class SetVarRequest : RequestBase<SetVarResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "setvar";

    /// <summary>
    /// The name of the variable
    /// </summary>
    [ApiParameter("var")]
    public string? VarName { get; set; }

    /// <summary>
    /// The value of the variable
    /// </summary>
    [ApiParameter("data")]
    public string? Data { get; set; }
}

