using System.Web;
using System.Web.Optimization;

namespace EZOper.TechTester.EZWebTemplate
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jqbspack.js").Include(
                        "~/Scripts/jQuery/jquery-3.1.1.js",
                        "~/Scripts/Bootstrap/v3.3.7/js/bootstrap.js",
                        "~/Scripts/jQuery.Validate/v1.16.0/jquery.validate*",
                        "~/Scripts/Modernizr/modernizr-{version}.js",
                        "~/Scripts/Respond/v1.4.2/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap.css").Include(
                      "~/Scripts/Bootstrap/v3.3.7/css/bootstrap.css",
                      "~/Scripts/Bootstrap/v3.3.7/css/bootstrap-theme.css"));
        }
    }
}
