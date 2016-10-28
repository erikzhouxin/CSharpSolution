using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.SQLiteWebSI.Areas.Home.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Home/Home
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}