using EZOper.TechTester.OAuth2ApiSI;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace EZOper.TechTester.OAuth2WebSI.Areas.OAuth2.Controllers
{
    /// <summary>
    /// GET: OAuth2/Account
    /// </summary>
    public class AccountController : Controller
    {
        public ActionResult LogOn(string returnUrl)
        {
            ViewBag.ReturnURL = returnUrl;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [SuppressMessage("Microsoft.Design", SuppressMsgDefinition.CA1054, Justification = SuppressMsgDefinition.JCA10541)]
        public ActionResult LogOn(string userName, bool? rememberMe, string returnUrl)
        {
            FormsAuthentication.SetAuthCookie(userName,  rememberMe ?? false);
            var service = ServiceFactory.GetOAuth2AuthService();
            if (service.IsUserNameValid(userName))
            {
                service.AddOAuthUsers(new OAuthUsers()
                {
                    Claimed = userName,
                    Friendly = userName,
                });
            }

            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}