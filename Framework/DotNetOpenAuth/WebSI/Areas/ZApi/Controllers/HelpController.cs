using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI.Areas.ZApi.Controllers
{
    /// <summary>
    /// 
    /// GET: ZApi/Help
    /// </summary>
    public class HelpController : Controller
    {
        public virtual ActionResult Api()
        {
            var explorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            var result = explorer.ApiDescriptions.ToLookup(api => api.ActionDescriptor.ControllerDescriptor.ControllerName);
            return View(result);
        }
    }
}