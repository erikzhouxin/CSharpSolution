using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.CSharpSolution.WebUI.Areas.Help.Controllers
{
    /// <summary>
    /// 百度图表ECharts控制器
    /// GET: Help/Echarts
    /// </summary>
    public class EchartsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}