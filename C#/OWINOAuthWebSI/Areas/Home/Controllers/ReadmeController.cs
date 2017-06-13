﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Microsoft.Owin.Hosting;
using System.Threading.Tasks;

namespace EZOper.TechTester.OWINOAuthWebSI.Areas.Home.Controllers
{
    /// <summary>
    /// 项目引用:https://github.com/yuezhongxin/OAuth2.Demo
    /// GET: Readme
    /// </summary>
    public class ReadmeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}