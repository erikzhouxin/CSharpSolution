using EZOper.TechTester.OAuth2ApiSI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI.Areas.OAuth2.Controllers
{
    /// <summary>
    /// GET: OAuth2/Home
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateDatabase()
        {
            var service = ServiceFactory.GetOAuth2AuthService();
            // Add the necessary row for the sample client.
            service.AddOAuthClient(new OAuthClient
            {
                Client = "samplewebapiconsumer",
                Secret = "samplesecret",
                Callback = string.Empty,
                Name = "Some sample client",
                Type = 0,
                Time = DateTime.Now,
            });
            service.AddOAuthClient(new OAuthClient
            {
                Client = "sampleImplicitConsumer",
                Secret = string.Empty,
                Callback = Request.Url.Authority,
                Name = "Some sample client used for implicit grants (no secret)",
                Type = 0,
                Time = DateTime.Now,
            });
            return this.View();
        }
    }
}