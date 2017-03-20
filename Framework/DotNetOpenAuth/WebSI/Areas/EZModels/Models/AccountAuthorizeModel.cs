using System.Collections.Generic;
using DotNetOpenAuth.OAuth2.Messages;

namespace EZOper.TechTester.OAuth2WebSI.Areas.EZModels
{
    public class AccountAuthorizeModel
    {
        public string ClientApp { get; set; }

        public HashSet<string> Scope { get; set; }

        public EndUserAuthorizationRequest AuthorizationRequest { get; set; }
    }
}
