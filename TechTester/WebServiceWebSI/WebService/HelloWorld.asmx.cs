using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace EZOper.TechTester.WebServiceWebSI.WebService
{
    /// <summary>
    /// HelloWorld 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class HelloWorld : System.Web.Services.WebService
    {
        [WebMethod]
        public string Say()
        {
            return "Hello World";
        }

        public HelloWorld()
        {
            //如果使用设计的组件，请取消注释以下行 
            //InitializeComponent(); 
        }

        [WebMethod(Description = "求和的方法")]
        public double addition(double i, double j)
        {
            return i + j;
        }
        [WebMethod(Description = "求差的方法")]
        public double subtract(double i, double j)
        {
            return i - j;
        }
        [WebMethod(Description = "求积的方法")]
        public double multiplication(double i, double j)
        {
            return i * j;
        }
        [WebMethod(Description = "求商的方法")]
        public double division(double i, double j)
        {
            if (j != 0)
                return i / j;
            else
                return 0;
        }
    }
}
