using System.Web.Optimization;
using Seldino.CrossCutting.Web.Bundle;

namespace Seldino.Web.UI
{
    public class ScriptBundleConfig : IBundleConfig
    {
        public void Register()
        {

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/old/jquery.min.js",
                "~/Scripts/old/alertify.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                "~/Scripts/old/jquery.unobtrusive-ajax.js",
                "~/Scripts/old/bootstrap.js",
                "~/Scripts/old/owl.carousel.min.js",
                "~/Scripts/old/jquery.mobile.custom.min.js",
                "~/Scripts/old/jquery.mCustomScrollbar.js",
                "~/Scripts/old/jquery.mousewheel-3.0.6.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/Supervision").Include(
                "~/Scripts/old/metisMenu.min.js",
                "~/Scripts/old/raphael-min.js",
                "~/Scripts/old/sb-admin-2.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/old/jquery.validate*"));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/datepicker").Include(
                "~/Scripts/old/bootstrap-datepicker.min.js",
                "~/Scripts/old/bootstrap-datepicker.fa.min.js",
                "~/Scripts/old/moment.min.js",
                "~/Scripts/old/moment-with-locales.min.js",
                "~/Scripts/old/moment-jalaali.js"
                ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/SelectList").Include(
               "~/Scripts/old/select2.js",
               "~/Scripts/old/select2_locale_fa.js"
               ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/leoJQuery").Include(
               "~/Scripts/jquery-1.10.2.js",
               "~/Scripts/components/flipclock.js",
               "~/Scripts/components/functions.js"
               ));

            BundleTable.Bundles.Add(new ScriptBundle("~/bundles/leoScripts").Include(
               "~/Scripts/bootstrap.rtl.min.js",
               "~/Scripts/components/nav.js",
               "~/Scripts/components/tabs.js",
               "~/Scripts/components/carousel.js",
               "~/Scripts/components/carousel-slide.js",
               "~/Scripts/components/price.js",
               "~/Scripts/components/search.js",
               "~/Scripts/components/parallax.js",
               "~/Scripts/components/side-nav.js",
               "~/Scripts/components/dropdown.js",
               "~/Scripts/components/input_field.js",
               "~/Scripts/components/toastr.js",
               "~/Scripts/components/card.js",
               "~/Scripts/components/load.js"
               ));
        }
    }
}
