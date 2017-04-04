using DotNetOpenAuth.OAuth2.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public class OAuthAccountAuthorizeViewModel
    {
        public string ClientApp { get; set; }

        public HashSet<string> Scope { get; set; }

        public EndUserAuthorizationRequest AuthorizationRequest { get; set; }
    }
}
