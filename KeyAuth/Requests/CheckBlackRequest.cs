using System.Collections.Specialized;
using System.Security.Principal;

namespace KeyAuth.Requests
{
    /// <summary>
    /// Blacklist check request
    /// </summary>
    public class CheckBlackRequest : RequestBase<Responses.CheckBlackResponse>
    {
        public override string Type => "checkblacklist";

        protected override NameValueCollection GetAdditionalParameters(string? sessionId, string name, string ownerId)
        {
            string? hwid = WindowsIdentity.GetCurrent().User?.Value;
            return new NameValueCollection
            {
                ["hwid"] = hwid ?? string.Empty
            };
        }
    }
}

