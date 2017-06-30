using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;
using System.Web.Security;
using System.Web.Http.Controllers;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http.Filters;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;

namespace EZOper.TechTester.JWTOAuthWebSI3.Areas.ZApi
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            base.OnAuthorization(actionContext);
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            string access_token = HttpContext.Current.Request.Cookies["access_token"].Value;
            var handler = new JwtSecurityTokenHandler();
            SecurityToken validToken = null;

            try
            {
                handler.ValidateToken(access_token, SysContext.JwtTokenValidationParameters, out validToken);
                var x = handler.ReadToken(access_token);
                var z = handler.ReadJwtToken(access_token);
                var validJwt = validToken as JwtSecurityToken;
                if (validJwt == null)
                {
                    AlertMsg = new JwtTokenAlertMsg() { Message = "Invalid JWT" };
                }
                else
                {
                    AlertMsg = new JwtTokenAlertMsg(true, "验证成功!") { statusCode = "200", expires_in = (int)(validJwt.ValidTo - validJwt.ValidFrom).TotalSeconds, access_token = access_token };
                }
            }
            catch (SecurityTokenValidationException ex)
            {
                AlertMsg = new JwtTokenAlertMsg() { Message = ex.Message };
            }
            catch (ArgumentException ex)
            {
                AlertMsg = new JwtTokenAlertMsg() { Message = ex.Message };
            }

            return AlertMsg.IsSuccess;
        }

        public JwtTokenAlertMsg AlertMsg { get; set; }

        protected override void HandleUnauthorizedRequest(HttpActionContext actionContext)
        {
            actionContext.Response = actionContext.Request.CreateResponse(AlertMsg);
        }
    }
}