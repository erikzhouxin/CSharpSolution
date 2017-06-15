using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;

namespace EZOper.TechTester.OWINOAuthWebSI.Areas.ZApi.Controllers
{
    /// <summary>
    /// 测试用户授权接口控制器
    /// GET: ZApi/TestOAuthApi
    /// </summary>
    public class TestOAuthApiController : System.Web.Mvc.Controller
    {
        public System.Web.Mvc.ActionResult Index()
        {
            return View();
        }
    }

    /// <summary>
    /// 测试用户授权控制器接口
    /// GET: Api/TestOAuth
    /// </summary>
    public class TestOAuthController : ApiController
    {
        /// <summary>
        /// 获取授权码
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        //[Route("api/authorization_code")]
        public HttpResponseMessage GetCode(string code)
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(code, Encoding.UTF8, "text/plain")
            };
        }

        /// <summary>
        /// 获取令牌
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[Route("api/access_token")]
        public HttpResponseMessage GetToken()
        {
            var url = Request.RequestUri;
            var result = new HttpResponseMessage()
            {
                Content = new StringContent("", Encoding.UTF8, "text/plain")
            };
            return result;
        }
        
        /// <summary>
        /// 验证功能数据
        /// </summary>
        /// <returns></returns>
        [Authorize]
        public IEnumerable<string> GetValue()
        {
            return new string[] { "value1", "value2", DateTime.Now.Ticks.ToString() };
        }
    }
}