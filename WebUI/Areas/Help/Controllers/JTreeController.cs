using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.CSharpSolution.WebUI.Areas.Help.Controllers
{
    /// <summary>
    /// 带搜索功能的jQuery树形菜单代码
    /// GET: Help/JTree
    /// <see cref="http://www.lanrenzhijia.com/demos/43/4309/demo/"/>
    /// </summary>
    public class JTreeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bootstrap()
        {
            return View();
        }
    }
}