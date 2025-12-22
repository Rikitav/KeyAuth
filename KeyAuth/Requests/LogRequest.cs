using System.Collections.Specialized;

namespace KeyAuth.Requests
{
    /// <summary>
    /// Event logging request
    /// </summary>
    public class LogRequest : RequestBase<Responses.LogResponse>
    {
        public override string Type => "log";

        [ApiParameter("message")]
        public string? Message { get; set; }

        protected override NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
        {
            return new NameValueCollection
            {
                ["pcuser"] = System.Environment.UserName
            };
        }
    }
}

