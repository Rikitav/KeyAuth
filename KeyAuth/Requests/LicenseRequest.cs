using System.Collections.Specialized;
using System.Security.Principal;

namespace KeyAuth.Requests
{
    /// <summary>
    /// License key authentication request
    /// </summary>
    public class LicenseRequest : RequestBase<Responses.LicenseResponse>
    {
        public override string Type => "license";

        [ApiParameter("key")]
        public string? Key { get; set; }

        [ApiParameter("code")]
        public string? Code { get; set; }

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

