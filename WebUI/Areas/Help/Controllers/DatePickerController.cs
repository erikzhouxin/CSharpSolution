using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.CSharpSolution.WebUI.Areas.Help.Controllers
{
    /// <summary>
    /// 时间选择控制器
    /// GET: Help/DatePicker
    /// </summary>
    public class DatePickerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BsDatePicker()
        {
            return View();
        }

        public ActionResult BsDateTimePicker()
        {
            return View();
        }
    }
}