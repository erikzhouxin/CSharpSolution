using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI.Areas.OAuth2.Controllers
{
    /// <summary>
    /// GET: OAuth2/OAuth
    /// </summary>
    public class OAuthController : Controller
    {
        public ActionResult Authorise()
        {
            return View();
        }
    }
}