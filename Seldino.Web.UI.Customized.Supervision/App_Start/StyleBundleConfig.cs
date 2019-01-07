using System.Web.Optimization;
using Seldino.CrossCutting.Web.Bundle;

namespace Seldino.Web.UI.Supervision
{
    public class StyleBundleConfig : IBundleConfig
    {
        public void Register()
        {
            BundleTable.Bundles.Add(new StyleBundle("~/Content/Default").Include(
                "~/Content/Css/bootstrap.css",
                "~/Content/css/bootstrap-rtl.css",
                "~/Content/Css/bootstrap-theme.css",
                "~/Content/Css/font-awesome.min.css",
                "~/Content/Css/alertify.core.css",
                "~/Content/Css/alertify.bootstrap.css"
                ));

            BundleTable.Bundles.Add(new StyleBundle("~/Content/Login").Include(
               "~/Content/Css/login.css"
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

        }
    }
}