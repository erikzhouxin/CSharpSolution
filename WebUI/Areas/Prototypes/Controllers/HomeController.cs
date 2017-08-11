using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.CSharpSolution.WebUI.Areas.Prototypes.Controllers
{
    /// <summary>
    /// 主页控制器
    /// GET: Prototypes/Home
    /// </summary>
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}