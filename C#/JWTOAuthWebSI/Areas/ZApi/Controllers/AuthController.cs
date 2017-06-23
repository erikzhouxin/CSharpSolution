using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Options;
using System.Security.Principal;
using System.Security.Claims;
using EZOper.TechTester.JWTOAuthWebSI.Services;
using Microsoft.AspNetCore.Authorization;

namespace EZOper.TechTester.JWTOAuthWebSI.Areas.ZApi.Controllers
{
    [Produces("application/json")]
    public class AuthController : AreaBaseController
    {
        [HttpPost]
        [Route("{id?}")]
        public IActionResult GetToken(string userName, string password)
        {
            var userModel = new JwtUserViewModel()
            {
                Audience = SysContext.JwtAudience,
                Issuer = SysContext.JwtIssuer,
                SigningKey = SysContext.JwtSigningKey,
                UserName = userName,
                Password = password,
            };
            var service = new AuthValidationService();
            var result = service.GetAuthToken(userModel);

            return Json(result);
        }
    }
}
