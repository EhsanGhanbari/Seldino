using System.Web.Optimization;

namespace Seldino.Web.UI.Supervision
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/Default").Include(
                "~/Content/Css/bootstrap.css",
                "~/Content/css/bootstrap-rtl.css",
                "~/Content/css/font-awesome.min.css",
                "~/Content/css/alertify.core.css",
                "~/Content/css/alertify.bootstrap.css",
                "~/Content/css/owl.carousel.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Login").Include(
                "~/Content/Css/login.css"
                ));

            bundles.Add(new StyleBundle("~/Content/Supervision").Include(
                "~/Content/Css/supervision-bootstrap-theme.css",
                "~/Content/Css/metisMenu.min.css",
                "~/Content/Css/timeline.css",
                "~/Content/Css/sb-admin-2.css",
                "~/Content/Css/morris.css"
                ));


            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
               "~/Scripts/jquery.min.js",
               "~/Scripts/alertify.js"
               ));
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/jquery.mobile.custom.min.js",
                "~/Scripts/jquery.mCustomScrollbar.js",
                "~/Scripts/jquery.mousewheel-3.0.6.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Supervision").Include(
                "~/Scripts/metisMenu.min.js",
                "~/Scripts/raphael-min.js",
                "~/Scripts/sb-admin-2.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Scripts/bootstrap-datepicker.min.js"
                //"~/Scripts/bootstrap-datepicker.fa.min.js"
                ));
        }
    }
}
