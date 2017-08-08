using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace EZOper.TechTester.JWTOAuthWebSI3.Areas.Help.Controllers
{
    /// <summary>
    /// 系统接口控制器
    /// GET: Help/ZApi
    /// The controller that will handle requests for the help page.
    /// </summary>
    public class ZApiController : Controller
    {
        private const string ErrorViewName = "Error";

        public ZApiController() : this(GlobalConfiguration.Configuration)
        {
        }

        public ZApiController(HttpConfiguration config)
        {
            Configuration = config;
        }

        public HttpConfiguration Configuration { get; private set; }

        public ActionResult Index()
        {
            ViewBag.DocumentationProvider = Configuration.Services.GetDocumentationProvider();
            return View(Configuration.Services.GetApiExplorer().ApiDescriptions);
        }

        public ActionResult Api(string apiId)
        {
            if (!String.IsNullOrEmpty(apiId))
            {
                HelpPageApiModel apiModel = Configuration.GetHelpPageApiModel(apiId);
                if (apiModel != null)
                {
                    return View(apiModel);
                }
            }

            return View(ErrorViewName);
        }

        public ActionResult ResourceModel(string modelName)
        {
            if (!String.IsNullOrEmpty(modelName))
            {
                ModelDescriptionGenerator modelDescriptionGenerator = Configuration.GetModelDescriptionGenerator();
                ModelDescription modelDescription;
                if (modelDescriptionGenerator.GeneratedModels.TryGetValue(modelName, out modelDescription))
                {
                    return View(modelDescription);
                }
            }

            return View(ErrorViewName);
        }

        /// <summary>
        /// 自定义Api列表显示
        /// </summary>
        /// <returns></returns>
        public virtual ActionResult TestApi()
        {
            var explorer = Configuration.Services.GetApiExplorer();
            var result = explorer.ApiDescriptions.ToLookup(api => api.ActionDescriptor.ControllerDescriptor.ControllerName);
            return View(result);
        }
    }
}