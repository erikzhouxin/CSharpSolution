using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EZOper.TechTester.OWINOAuthWebSI.Areas.ZApi.Controllers
{
    /// <summary>
    /// 
    /// GET: ZApi/Home
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}