using KeyAuth.Responses;

namespace KeyAuth.Requests;

/// <summary>
/// Represents a request to download a file
/// </summary>
public class DownloadRequest : RequestBase<DownloadResponse>
{
    /// <summary>
    /// The type of the request
    /// </summary>
    public override string Type => "file";

    /// <summary>
    /// The ID of the file to download
    /// </summary>
    [ApiParameter("fileid")]
    public string? FileId { get; set; }
}

