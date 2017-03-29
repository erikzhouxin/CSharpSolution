using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Linq;

namespace EZOper.TechTester.OAuth2WebSI.Areas.ZApi.Controllers
{
    /// <summary>
    /// ½Ó¿ÚÓò°ïÖú¿ØÖÆÆ÷
    /// GET: ZApi/Help
    /// </summary>
    public class HelpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Api()
        {
            var explorer = GlobalConfiguration.Configuration.Services.GetApiExplorer();
            var result = explorer.ApiDescriptions.ToLookup(api => api.ActionDescriptor.ControllerDescriptor.ControllerName);
            return View(result);
        }
    }
}