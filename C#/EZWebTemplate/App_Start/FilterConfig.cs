using System.Web;
using System.Web.Mvc;

namespace EZOper.TechTester.EZWebTemplate
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
