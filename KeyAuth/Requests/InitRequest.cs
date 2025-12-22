using KeyAuth.Utilities;
using System.Collections.Specialized;
using System.Diagnostics;

namespace KeyAuth.Requests
{
    /// <summary>
    /// KeyAuth initialization request
    /// </summary>
    public class InitRequest : RequestBase<Responses.InitResponse>
    {
        public override string Type => "init";

        [ApiParameter("name")]
        public string? Name { get; set; }

        [ApiParameter("ownerid")]
        public string? OwnerId { get; set; }

        [ApiParameter("ver")]
        public string? Version { get; set; }

        [IgnoreApiParameter]
        public string? TokenPath { get; set; }

        protected override NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
        {
            var parameters = new NameValueCollection
            {
                ["hash"] = KeyAuthHelper.Checksum(Process.GetCurrentProcess().MainModule.FileName)
            };

            if (!string.IsNullOrEmpty(TokenPath))
            {
                parameters.Add("token", System.IO.File.ReadAllText(TokenPath));
                parameters.Add("thash", KeyAuthHelper.TokenHash(TokenPath));
            }

            return parameters;
        }
    }
}

