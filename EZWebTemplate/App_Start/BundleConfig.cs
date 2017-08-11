using System.Web;
using System.Web.Optimization;

namespace EZOper.TechTester.EZWebTemplate
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery.js").Include(
                        "~/Scripts/Lib/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval.js").Include(
                        "~/Scripts/Lib/jquery.validate*"));

            // 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr.js").Include(
                        "~/Scripts/Modernizr/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap.js").Include(
                      "~/Scripts/Bootstrap/v3.3.7/js/bootstrap.js",
                      "~/Scripts/Respond/v1.2.0/respond.js"));

            bundles.Add(new StyleBundle("~/bundles/bootstrap.css").Include(
                      "~/Scripts/Bootstrap/v3.3.7/css/bootstrap.css",
                      "~/Scripts/Bootstrap/v3.3.7/css/bootstrap-theme.css"));
        }
    }
}
