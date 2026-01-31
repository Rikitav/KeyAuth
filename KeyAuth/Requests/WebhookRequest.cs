using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to call a webhook
/// </summary>
public class WebhookRequest : RequestBase<WebhookResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "webhook";

    /// <summary>
    /// The ID of the webhook
    /// </summary>
    [ApiParameter("webid")]
    public string? WebId { get; set; }

    /// <summary>
    /// The parameters to pass to the webhook
    /// </summary>
    [ApiParameter("params")]
    public string? Params { get; set; }

    /// <summary>
    /// The body of the request
    /// </summary>
    [ApiParameter("body")]
    public string? Body { get; set; }

    /// <summary>
    /// The content type of the request
    /// </summary>
    [ApiParameter("conttype")]
    public string? ContentType { get; set; }
}

