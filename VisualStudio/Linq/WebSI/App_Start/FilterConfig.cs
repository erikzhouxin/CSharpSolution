using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.LinqWebSI
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
