using KeyAuth.Utilities;
using System.Text.Json.Serialization;

namespace KeyAuth.Responses;

/// <summary>
/// Represents a response to a file download request
/// </summary>
public class DownloadResponse : ResponseBase
{
    [JsonPropertyName("contents")]
    private string? _contents;

    /// <summary>
    /// The contents of the downloaded file
    /// </summary>
    public byte[]? Contents
    {
        get
        {
            if (string.IsNullOrEmpty(_contents))
                return null;

            return EncryptionHelper.ToByteArray(_contents);
        }

        set
        {
            _contents = EncryptionHelper.ToString(value!);
        }
    }
}

