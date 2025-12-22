using System.Collections.Specialized;
using System.Security.Principal;

namespace KeyAuth.Requests
{
    /// <summary>
    /// New user registration request
    /// </summary>
    public class RegisterRequest : RequestBase<Responses.RegisterResponse>
    {
        public override string Type => "register";

        [ApiParameter("username")]
        public string? Username { get; set; }

        [ApiParameter("pass")]
        public string? Password { get; set; }

        [ApiParameter("key")]
        public string? Key { get; set; }

        [ApiParameter("email")]
        public string? Email { get; set; }

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

