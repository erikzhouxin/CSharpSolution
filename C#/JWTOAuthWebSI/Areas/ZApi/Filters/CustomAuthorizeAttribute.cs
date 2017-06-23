using System;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;

namespace EZOper.TechTester.JWTOAuthWebSI.Areas.ZApi
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string claimType = JwtRegisteredClaimNames.Sub, string claimValue = "")
            : base(typeof(CustomAuthorizeActionFilter))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }

    public class CustomAuthorizeActionFilter : IAsyncActionFilter
    {
        readonly Claim _claim;

        public CustomAuthorizeActionFilter(Claim claim)
        {
            _claim = claim;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var access_token = context.HttpContext.Request.Cookies["access_token"];
            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal principal = null;
            SecurityToken validToken = null;

            try
            {
                principal = handler.ValidateToken(access_token, SysContext.JwtTokenValidationParameters, out validToken);
                var validJwt = validToken as JwtSecurityToken;
                if (validJwt == null)
                {
                    throw new ArgumentException("Invalid JWT");
                }
                // Additional custom validation of JWT claims here (if any)
            }
            catch (SecurityTokenValidationException ex)
            {
                context.Result = new JsonResult(new JwtTokenAlertMsg() { statusCode = "400", Message = ex.Message });
                return;
            }
            catch (ArgumentException ex)
            {
                context.Result = new JsonResult(new JwtTokenAlertMsg() { statusCode = "400", Message = ex.Message });
                return;
            }

            // Validation passed. Return a valid AuthenticationTicket:
            await next();
        }
    }

}