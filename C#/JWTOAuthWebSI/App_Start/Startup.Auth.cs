using System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Configuration;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;

namespace EZOper.TechTester.JWTOAuthWebSI
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            var issuer = ConfigurationManager.AppSettings["issuer"];
            var secret = TextEncodings.Base64Url.Decode(Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(ConfigurationManager.AppSettings["secret"])));
            secret = System.Text.Encoding.Default.GetBytes(ConfigurationManager.AppSettings["secret"]);

            //用jwt进行身份认证
            app.UseJwtBearerAuthentication(new JwtBearerAuthenticationOptions
            {
                AuthenticationMode = AuthenticationMode.Active,
                AllowedAudiences = new[] { "Any" },
                IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[] { new SymmetricKeyIssuerSecurityTokenProvider(issuer, secret) }
            });

            app.UseOAuthAuthorizationServer(new OAuthAuthorizationServerOptions
            {
                AllowInsecureHttp = true,
                AuthenticationMode = AuthenticationMode.Active,
                //请求token的路径
                TokenEndpointPath = new PathString("/jwtoauth2token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(30),
                //定义token信息格式 
                AccessTokenFormat = new CustomJwtFormat(issuer, secret),
                //请求获取token时，验证username, password
                Provider = new CustomOAuthProvider(),
            });
        }
    }
}