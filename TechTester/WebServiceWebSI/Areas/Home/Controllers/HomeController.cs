using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.WebServiceWebSI.Areas.Home.Controllers
{
    public partial class HomeController : Controller
    {
        // GET: Home/Home
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult GetResult(double value1, double value2, string operSymbols)
        {
            App_WebReferences.HelloWorldSoap web = new App_WebReferences.HelloWorldSoapClient();
            KeyValuePair<string, double> result;
            switch (operSymbols)
            {
                case "+":
                    var sumValue = web.addition(value1, value2);
                    result = new KeyValuePair<string, double>(string.Format("{0} {1} {2} = {3}", value1, operSymbols, value2, sumValue), sumValue);
                    break;
                case "-":
                    var minusValue = web.subtract(value1, value2);
                    result = new KeyValuePair<string, double>(string.Format("{0} {1} {2} = {3}", value1, operSymbols, value2, minusValue), minusValue);
                    break;
                case "*":
                    var momValue = web.multiplication(value1, value2);
                    result = new KeyValuePair<string, double>(string.Format("{0} {1} {2} = {3}", value1, operSymbols, value2, momValue), momValue);
                    break;
                case "/":
                    var divisValue = web.division(value1, value2);
                    result = new KeyValuePair<string, double>(string.Format("{0} {1} {2} = {3}", value1, operSymbols, value2, divisValue), divisValue);
                    break;
                default:
                    result = new KeyValuePair<string, double>("", 0);
                    break;
            }
            return Json(result);
        }
    }
}