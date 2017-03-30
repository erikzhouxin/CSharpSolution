using DotNetOpenAuth.OAuth2;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace EZOper.TechTester.OAuth2ApiSI
{

    public class AuthenticationServiceHandler : DelegatingHandler
    {
        private readonly AuthenticationConfiguration _configuration;

        public AuthenticationServiceHandler(AuthenticationConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            try
            {
                if (request.Headers.All(x => x.Key != "Authorization"))
                    return base.SendAsync(request, cancellationToken);
                string authHeader = request.Headers.GetValues("Authorization").FirstOrDefault();
                if (authHeader == null)
                    return base.SendAsync(request, cancellationToken);
                string header = "Bearer ";

                if (string.CompareOrdinal(authHeader, 0, header, 0, header.Length) == 0)
                {
                    using (var signing = _configuration.CreateAuthorizationServerSigningServiceProvider())
                    {
                        using (var encrypting = _configuration.CreateResourceServerEncryptionServiceProvider())
                        {
                            var resourceServer = new WebAPIResourceServer(new StandardAccessTokenAnalyzer(signing, encrypting));
                            var principal = resourceServer.GetPrincipal(request, request.RequestUri.AbsoluteUri);
                            if (principal != null)
                            {
                                SetPrincipal(principal);
                            }
                        }
                    }
                }
                else
                {
                    return SendUnauthorizedResponse();
                }
            }
            catch (SecurityTokenValidationException)
            {
                return SendUnauthorizedResponse();
            }

            return base.SendAsync(request, cancellationToken).ContinueWith(
                (task) =>
                {
                    var response = task.Result;

                    if (response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        SetAuthenticateHeader(response);
                    }

                    return response;
                });
        }

        private Task<HttpResponseMessage> SendUnauthorizedResponse()
        {
            return Task<HttpResponseMessage>.Factory.StartNew(() =>
            {
                var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                SetAuthenticateHeader(response);
                return response;
            });
        }

        protected virtual void SetAuthenticateHeader(HttpResponseMessage response)
        {
            //response.Headers.WwwAuthenticate.Add(new AuthenticationHeaderValue(_authN.Configuration.DefaultAuthenticationScheme));
        }

        protected virtual void SetPrincipal(IPrincipal principal)
        {
            Thread.CurrentPrincipal = principal;
            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }
        }
    }
}
