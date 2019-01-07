using System.IO;
using System.Web.Mvc;

namespace Seldino.CrossCutting.Web.Helpers
{
    public static class SeldinoHtmlHelper
    {
        public static MvcHtmlString GetImageUrl(this HtmlHelper htmlHelper, string imageUrl)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return MvcHtmlString.Empty;
            }

            return MvcHtmlString.Create($"{Path.GetDirectoryName(imageUrl).Replace('\\', '/').Replace("~/", string.Empty)}/{Path.GetFileNameWithoutExtension(imageUrl)}{Path.GetExtension(imageUrl)}");
        }

        public static MvcHtmlString GetImageUrl(this HtmlHelper htmlHelper, string imageUrl, int width, int height)
        {
            if (string.IsNullOrEmpty(imageUrl))
            {
                return MvcHtmlString.Empty;
            }

            return MvcHtmlString.Create($"{Path.GetDirectoryName(imageUrl).Replace('\\', '/')}/{Path.GetFileNameWithoutExtension(imageUrl)}-{width}x{height}{Path.GetExtension(imageUrl)}");
        }
    }
}
