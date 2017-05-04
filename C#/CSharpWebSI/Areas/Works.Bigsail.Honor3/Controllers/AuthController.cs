using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.CSharpWebSI.Areas.Works.Bigsail.Honor3.Controllers
{
    /// <summary>
    /// 工作域/云帆科技/Honor3(办学条件监测管理系统)/授权控制器
    /// GET: Works/Bigsail/Honor3/Auth
    /// </summary>
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOn()
        {
            return View();
        }
    }
}