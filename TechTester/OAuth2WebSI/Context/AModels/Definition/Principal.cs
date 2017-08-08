using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Claims;

namespace EZOper.TechTester.OAuth2ApiSI
{
    public static class Principal
    {
        public static ClaimsPrincipal Anonymous
        {
            get
            {
                var anonId = new ClaimsIdentity();
                var anonPrincipal = ClaimsPrincipal.CreateFromIdentity(anonId);
                return anonPrincipal as ClaimsPrincipal;
            }
        }

        public static ClaimsPrincipal Create(string authenticationType, params Claim[] claims)
        {
            return new ClaimsPrincipal(new IClaimsIdentity[] { new ClaimsIdentity(claims, authenticationType) });
        }
    }
}
