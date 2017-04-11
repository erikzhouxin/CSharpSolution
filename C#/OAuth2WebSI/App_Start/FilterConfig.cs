using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.OAuth2WebSI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
