using System.Web;
using System.Web.Optimization;

namespace OnlineUserToDoList
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/lib/jquery/jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/lib/jquery-validate/jquery.validate.js"));

            bundles.Add(new ScriptBundle("~/bundles/datatabel").Include(
                "~/lib/datatable/js/datatable.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/sweetalert").Include(
                "~/lib/sweetalert/sweetalert.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/lib/datatable/css/datatable.css",
                      "~/Content/site.css"));
        }
    }
}
