using System.Web.Optimization;

namespace Evaluation.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.blockui.js"));
        
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/font-awesome-4.7.0/css/font-awesome.min.css",
                "~/Content/bootstrap.css",
                "~/Content/Site.css"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/angular-animate.min.js",
                "~/Scripts/angular-resource.min.js",
                "~/Scripts/angular-route.min.js",
                "~/Scripts/angular-ui-bootstrap.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Scripts/app/app.js",
                "~/Scripts/app/common.js",
                "~/Scripts/app/betControllers.js",
                "~/Scripts/app/betServices.js"));
        }
    }
}