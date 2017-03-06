using EZOper.TechTester.OAuth2ApiBLL;
using EZOper.TechTester.OAuth2ApiDEMV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI.Areas.Home.Controllers
{
    /// <summary>
    /// 身份验证控制器
    /// GET: Home/Auth
    /// </summary>
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult LogOn(string errorMsg)
        {
            var model = new LogOnViewModel()
            {
                Account = Request["Account"],
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult LogOn(LogOnViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (!SysContext.IsValidAuthCode(model.AuthCode))
            {
                TempData[SysContext.TempData_ErrorMsg] = "验证码错误，请重新输入";
                model.AuthCode = string.Empty;
                return RedirectToAction("LogOn", model);
            }
            var process = ServiceFactory.GetAuthService();
            var isPass = process.IsValid(model);
            if (isPass)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData[SysContext.TempData_ErrorMsg] = "密码或用户名错误，请重新输入";
            model.AuthCode = string.Empty;
            return RedirectToAction("LogOn", model);
        }

        public ActionResult VerifyCode()
        {
            var result = AuthCode.GetGraphic(4);
            Session[SysContext.Session_AuthCode] = result.Key;
            return File(result.Value, @"image/jpeg");
        }
    }
}