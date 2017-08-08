using System;
using Microsoft.IdentityModel.Tokens;

namespace EZOper.TechTester.JWTOAuthWebSI.Services.JWTCommon
{
    public class TokenProviderOptions
    {
        public string Path { get; set; } = "/auth/token";

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(10);

        public SigningCredentials SigningCredentials { get; set; }
    }
}
