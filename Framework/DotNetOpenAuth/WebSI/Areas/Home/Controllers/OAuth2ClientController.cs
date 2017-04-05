using DotNetOpenAuth.Messaging;
using DotNetOpenAuth.OAuth2;
using EZOper.TechTester.OAuth2ApiSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI.Areas.Home.Controllers
{
    /// <summary>
    /// GET: Home/OAuth2Client
    /// </summary>
    public class OAuth2ClientController : Controller
    {
        public const string HostBaseUrl = "http://localhost:55142";
        public const string ClientBaseUrl = "http://localhost:55142";

        public IAuthorizationState Authorization { get; private set; }
        public UserAgentClient Client { get; set; }

        public OAuth2ClientController()
        {
            var authServer = new AuthorizationServerDescription()
            {
                AuthorizationEndpoint = new Uri(HostBaseUrl + "/OAuth2/OAuth/Authorise"),
                TokenEndpoint = new Uri(HostBaseUrl + "/OAuth2/OAuth/Token"),
            };
            this.Client = new UserAgentClient(authServer, "EZOper.TechTester.OAuth2WebSI", "erikzhouxin");
            this.Authorization = new AuthorizationState();
            this.Authorization.Callback = new Uri(ClientBaseUrl + "/OAuth2Client/Index");
        }
        public ActionResult Index()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["code"]))
            {
                try
                {
                    this.Client.ProcessUserAuthorization(Request.Url, this.Authorization);
                    var valueString = string.Empty;
                    if (!string.IsNullOrEmpty(this.Authorization.AccessToken))
                    {
                        valueString = CallAPI(this.Authorization);
                    }
                    ViewBag.Values = valueString;
                }
                catch (ProtocolException ex)
                {
                    ViewBag.Values = ex.Message;
                }
            }
            return View();
        }

        private string CallAPI(IAuthorizationState authorization)
        {
            var webClient = new WebClient();
            webClient.Headers["Content-Type"] = "application/json";
            webClient.Headers["X-JavaScript-User-Agent"] = "Demo";
            this.Client.AuthorizeRequest(webClient, this.Authorization);
            var valueString = webClient.DownloadString(HostBaseUrl + "/api/values/get");
            return valueString;
        }

        public JsonResult GetValues()
        {
            bool isOK = false;
            bool requiresAuth = false;
            string redirectURL = "";
            if (Session["AccessToken"] == null)
            {
                this.Authorization.Scope.AddRange(OAuthUtilities.SplitScopes(HostBaseUrl + "/api/values/get"));
                Uri authorizationUrl = this.Client.RequestUserAuthorization(this.Authorization);
                requiresAuth = true;
                redirectURL = authorizationUrl.AbsoluteUri;
                isOK = true;
            }
            else
            {
                requiresAuth = false;
            }
            return new JsonResult()
            {
                Data = new
                {
                    OK = isOK,
                    RequiresAuth = requiresAuth,
                    RedirectURL = redirectURL
                }
            };
        }
    }
}