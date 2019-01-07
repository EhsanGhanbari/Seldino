using System.Web.Optimization;
using Seldino.CrossCutting.Web.Bundle;

namespace Seldino.Web.UI.Supervision
{
    public class ScriptBundleConfig : IBundleConfig
    {
        public void Register()
        {

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery.min.js",
                "~/Scripts/alertify.js"
                ));
            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                "~/Scripts/jquery.unobtrusive-ajax.js",
                "~/Scripts/bootstrap.js",
                "~/Scripts/owl.carousel.min.js",
                "~/Scripts/jquery.mobile.custom.min.js",
                "~/Scripts/jquery.mCustomScrollbar.js",
                "~/Scripts/jquery.mousewheel-3.0.6.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/Supervision").Include(
                "~/Scripts/metisMenu.min.js",
                "~/Scripts/raphael-min.js",
                "~/Scripts/sb-admin-2.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/bootstrap-datepicker.fa.min.js",
                "~/Scripts/moment.min.js",
                "~/Scripts/moment-with-locales.min.js",
                "~/Scripts/moment-jalaali.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/SelectList").Include(
               "~/Scripts/select2.js",
               "~/Scripts/select2_locale_fa.js"
               ));
        }
    }
}