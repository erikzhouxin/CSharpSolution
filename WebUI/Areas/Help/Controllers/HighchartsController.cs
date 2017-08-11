using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.CSharpSolution.WebUI.Areas.Help.Controllers
{
    /// <summary>
    /// 图表Highcharts控制器
    /// GET: Help/Highcharts
    /// </summary>
    public class HighchartsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}