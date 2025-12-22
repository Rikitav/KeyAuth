using KeyAuth.Utilities;
using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to file download request
    /// </summary>
    public class DownloadResponse : ResponseBase
    {
        [JsonPropertyName("contents")]
        private string? _contents;

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
}

