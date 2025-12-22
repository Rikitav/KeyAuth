using System.Text.Json.Serialization;

namespace KeyAuth.Responses
{
    /// <summary>
    /// Response to global variable request
    /// </summary>
    public class VarResponse : ResponseBase
    {
        [JsonPropertyName("ownerid")]
        public string? OwnerId { get; set; }

        /// <summary>
        /// Variable value (stored in the message field of the response)
        /// </summary>
        public string? Value => Message;
    }
}

