using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EZOper.TechTester.JWTOAuthWebSI
{
    public class JwtUserViewModel
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        /// <summary>
        ///  The Issuer (iss) claim for generated tokens.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// The Audience (aud) claim for the generated tokens.
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// The expiration time for the generated tokens.
        /// </summary>
        /// <remarks>The default is five minutes (300 seconds).</remarks>
        public TimeSpan Expiration { get; set; } = TimeSpan.FromMinutes(5);

        public string SigningKey { get; set; }
    }
}
