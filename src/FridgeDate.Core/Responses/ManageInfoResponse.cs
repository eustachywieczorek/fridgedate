using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeDate.Core.Responses
{
    public class ManageInfoResponse
    {
        public string LocalLoginProvider { get; set; }

        public string Email { get; set; }

        public IEnumerable<UserLoginInfo> Logins { get; set; }

        public IEnumerable<ExternalLogin> ExternalLoginProviders { get; set; }
    }

    public class UserLoginInfo
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }

    public class ExternalLogin
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public string State { get; set; }
    }
}
