using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Web;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using EZOper.TechTester.OAuth2ApiBLL;

namespace EZOper.TechTester.OAuth2WebSI.Areas.EZModels.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsAuth { get; private set; }

        public IAccountMembershipService MembershipService { get; private set; }
        public AccountController()
            : this(null, null)
        {
        }

        public AccountController(IFormsAuthenticationService formsAuth, IAccountMembershipService service)
        {
            this.FormsAuth = formsAuth ?? EZModelsServiceFactory.GetFormsAuthenticationService();
            this.MembershipService = service ?? EZModelsServiceFactory.GetAccountMembershipService();
        }
        public ActionResult LogOn(string returnURL)
        {
            ViewBag.ReturnURL = returnURL;
            return View();
        }
        [AcceptVerbs(HttpVerbs.Post)]
        [SuppressMessage("Microsoft.Design", "CA1054:UriParametersShouldNotBeStrings",
            Justification = "Needs to take same parameter type as Controller.Redirect()")]
        public ActionResult LogOn(string userName, bool? rememberMe, string returnUrl)
        {
            this.FormsAuth.SignIn(userName, rememberMe ?? false);
            //if (WebApiApplication.DataContext.Users.FirstOrDefault(u => u.OpenIDClaimedIdentifier == userName) == null)
            //{
            //    WebApiApplication.DataContext.Users.InsertOnSubmit(new User
            //    {
            //        OpenIDFriendlyIdentifier = userName,
            //        OpenIDClaimedIdentifier = userName,
            //    });
            //}

            if (!String.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}
