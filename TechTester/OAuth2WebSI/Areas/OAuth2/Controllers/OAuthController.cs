﻿using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth2;
using EZOper.TechTester.OAuth2ApiSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI.Areas.OAuth2.Controllers
{
    /// <summary>
    /// GET: OAuth2/OAuth
    /// </summary>
    public class OAuthController : Controller
    {
        /// <summary>
        /// The OAuth 2.0 token endpoint.
        /// </summary>
        /// <returns>The response to the Client.</returns>
        public ActionResult Token()
        {
            var authorizationServer = new AuthorizationServer(new OAuth2AuthorizationServerHost());
            return authorizationServer.HandleTokenRequest(this.Request).AsActionResultMvc5();
        }

        /// <summary>
        /// Prompts the user to authorize a client to access the user's private data.
        /// </summary>
        /// <returns>The browser HTML response that prompts the user to authorize the client.</returns>
        [Authorize, AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        //[HttpHeader("x-frame-options", "SAMEORIGIN")] // mitigates clickjacking
        public ActionResult Authorise()
        {
            var authorizationServer = new AuthorizationServer(new OAuth2AuthorizationServerHost());
            var pendingRequest = authorizationServer.ReadAuthorizationRequest();
            if (pendingRequest == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Missing authorization request.");
            }
            var service = ServiceFactory.GetOAuth2AuthService();
            var requestingClient = service.GetOAuthClient(pendingRequest.ClientIdentifier);

            // Consider auto-approving if safe to do so.
            if (((OAuth2AuthorizationServerHost)authorizationServer.AuthorizationServerServices).CanBeAutoApproved(pendingRequest))
            {
                var approval = authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, HttpContext.User.Identity.Name);
                return authorizationServer.Channel.PrepareResponse(approval).AsActionResultMvc5();
            }

            var model = new OAuthAccountAuthorizeViewModel
            {
                ClientApp = requestingClient.Name,
                Scope = pendingRequest.Scope,
                AuthorizationRequest = pendingRequest,
            };

            return View(model);
        }

        /// <summary>
        /// Processes the user's response as to whether to authorize a Client to access his/her private data.
        /// </summary>
        /// <param name="isApproved">if set to <c>true</c>, the user has authorized the Client; <c>false</c> otherwise.</param>
        /// <returns>HTML response that redirects the browser to the Client.</returns>
        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public ActionResult AuthoriseResponse(bool isApproved)
        {
            var authorizationServer = new AuthorizationServer(new OAuth2AuthorizationServerHost());
            var pendingRequest = authorizationServer.ReadAuthorizationRequest();
            if (pendingRequest == null)
            {
                throw new HttpException((int)HttpStatusCode.BadRequest, "Missing authorization request.");
            }

            IDirectedProtocolMessage response;
            if (isApproved)
            {
                // The authorization we file in our database lasts until the user explicitly revokes it.
                // You can cause the authorization to expire by setting the ExpirationDateUTC
                // property in the below created ClientAuthorization.
                var service = ServiceFactory.GetOAuth2AuthService();
                var client = service.GetOAuthClient(pendingRequest.ClientIdentifier);
                var user = service.GetOAuthUsers(HttpContext.User.Identity.Name);
                service.AddOAuthClientAuthor(new OAuthClientAuthor
                {
                    UserID = user.ID,
                    ClientID = client.ID,
                    Scope = OAuthUtilities.JoinScopes(pendingRequest.Scope),
                    ExpireUtc = DateTime.Now.AddDays(1),
                    Time = DateTime.Now,
                });
                // submit now so that this new row can be retrieved later in this same HTTP request

                // In this simple sample, the user either agrees to the entire scope requested by the client or none of it.  
                // But in a real app, you could grant a reduced scope of access to the client by passing a scope parameter to this method.
                response = authorizationServer.PrepareApproveAuthorizationRequest(pendingRequest, User.Identity.Name);
            }
            else
            {
                response = authorizationServer.PrepareRejectAuthorizationRequest(pendingRequest);
            }

            return authorizationServer.Channel.PrepareResponse(response).AsActionResultMvc5();
        }
    }
}