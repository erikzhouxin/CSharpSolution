using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace EZOper.TechTester.JWTOAuthWebSI3
{
    public static class SysContext
    {
        public static readonly string JwtAudience = "ExampleAudience";// Configration.GetKey("JwtAudience");
        public static readonly string JwtIssuer = "ExampleIssuer";// Configration.GetKey("JwtIssuer");
        public static readonly string JwtSigningKey = "EZOper.TechTester.JWTOAuthWebSI";// Configration.GetKey("JwtSigningKey");

        public static readonly SecurityKey JwtSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtSigningKey));
        public static readonly TokenValidationParameters JwtTokenValidationParameters = new TokenValidationParameters
        {
            // The signing key must match!
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = JwtSecurityKey,

            // Validate the JWT Issuer (iss) claim
            ValidateIssuer = true,
            ValidIssuer = JwtIssuer,

            // Validate the JWT Audience (aud) claim
            ValidateAudience = true,
            ValidAudience = JwtAudience,

            // Validate the token expiry
            ValidateLifetime = true,

            // If you want to allow a certain amount of clock drift, set that here:
            ClockSkew = TimeSpan.Zero
        };
    }
}