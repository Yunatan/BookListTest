using System.Web.Optimization;

namespace BookList.Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/js/jquery").Include(
                "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jqueryui").Include(
                "~/Scripts/jquery/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/js/jtable").Include(
                "~/Scripts/jtable/jquery.jtable.js",
                "~/Scripts/jquery/jquery.validationEngine.js",
                "~/Scripts/jquery/jquery.validationEngine-en.js",
                "~/Scripts/jquery/jquery.form.js"));

            bundles.Add(new StyleBundle("~/bundles/css/jqueryui").IncludeDirectory(
                "~/Content/themes/base", "*.css"));

            bundles.Add(new StyleBundle("~/bundles/css/jtable").Include(
                "~/Scripts/jtable/themes/metro/green/jtable.css",
                "~/Content/validationEngine.jquery.css"));
        }
    }
}