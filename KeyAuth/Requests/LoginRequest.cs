using System.Collections.Specialized;
using System.Security.Principal;

namespace KeyAuth.Requests
{
    /// <summary>
    /// Login request with username and password
    /// </summary>
    public class LoginRequest : RequestBase<Responses.LoginResponse>
    {
        public override string Type => "login";

        [ApiParameter("username")]
        public string? Username { get; set; }

        [ApiParameter("pass")]
        public string? Password { get; set; }

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

