using System.Web.Optimization;
using Seldino.CrossCutting.Web.Bundle;

namespace Seldino.Web.UI
{
    public class StyleBundleConfig : IBundleConfig
    {
        public void Register()
        {
            BundleTable.Bundles.Add(new StyleBundle("~/Content/Default").Include(
                "~/Content/Css/bootstrap.css",
                "~/Content/Css/bootstrap-rtl.css",
                "~/Content/Css/font-awesome.min.css",
                "~/Content/Css/alertify.core.css",
                "~/Content/Css/alertify.bootstrap.css",
                "~/Content/Css/owl.carousel.css"
                ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/Css").Include(
                "~/Content/Css/bootstrap-theme.css",
                "~/Content/Css/style.css",
                "~/Content/Css/jquery.mCustomScrollbar.css"
                ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/Supervision").Include(
                "~/Content/Css/supervision-bootstrap-theme.css",
                "~/Content/Css/metisMenu.min.css",
                "~/Content/Css/timeline.css",
                "~/Content/Css/sb-admin-2.css",
                "~/Content/Css/morris.css"
                ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/Datepicker").Include(
                "~/Content/Css/bootstrap-datepicker.min.css"
                ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/SelectList").Include(
                "~/Content/Css/select2.css"
                ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/leoStyle").Include(
                "~/Content/bootstrap.rtl.min.css",
                "~/Content/components/input_style.css",
                "~/Content/components/animate.css",
                "~/Content/components/carousel.css",
                "~/Content/components/parallax.css",
                "~/Content/components/carousel.css",
                "~/Content/components/search.css",
                "~/Content/components/side-nav.css",
                "~/Content/components/dropdown.css",
                "~/Content/components/flipclock.css",
                "~/Content/components/input_field.css",
                "~/Content/components/card.css",
                "~/Content/components/toastr.css",
                "~/Content/nav.css",
                "~/Content/tabs.css",
                "~/Content/carousel-slide.css",
                "~/Content/product.css",
                "~/Content/farsiFonts/yekan.css",
                "~/Content/font-awesome.css",
                "~/Content/Site.css"
                ));

        }
    }
}