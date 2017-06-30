using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EZOper.TechTester.JWTOAuthWebSI3.Services
{
    public class AuthValidationService
    {
        public JwtTokenAlertMsg GetAuthToken(JwtUserViewModel model)
        {
            var username = model.UserName;
            var password = model.Password;
            var identity = GetClaimsIdentity(username, password);
            if (identity == null)
            {
                return new JwtTokenAlertMsg { statusCode = "400", Message = "Invalid username or password." };
            }

            var now = DateTime.Now;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(now).ToString(), ClaimValueTypes.Integer64)
            };
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(model.SigningKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
                issuer: model.Issuer,
                audience: model.Audience,
                claims: claims,
                notBefore: now,
                expires: now.Add(model.Expiration),
                signingCredentials: signingCredentials);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new JwtTokenAlertMsg
            {
                statusCode = "200",
                Message = "登录成功",
                access_token = encodedJwt,
                expires_in = (int)model.Expiration.TotalSeconds,
            };
            
            return response;
        }

        public ClaimsIdentity GetClaimsIdentity(string username, string password)
        {
            // ToDo:验证密码

            return new ClaimsIdentity(new GenericIdentity(username, "Token"), new Claim[] { });
        }

        /// <summary>
        /// Get this datetime as a Unix epoch timestamp (seconds since Jan 1, 1970, midnight UTC).
        /// </summary>
        /// <param name="date">The date to convert.</param>
        /// <returns>Seconds since Unix epoch.</returns>
        public static long ToUnixEpochDate(DateTime date) => new DateTimeOffset(date).ToUniversalTime().ToUnixTimeSeconds();
    }
}
