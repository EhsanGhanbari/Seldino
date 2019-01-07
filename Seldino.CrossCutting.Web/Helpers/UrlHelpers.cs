using System;
using System.Web.Mvc;
using Seldino.CrossCutting.Web.Routings;

namespace Seldino.CrossCutting.Web.Helpers
{
    public static class UrlHelpers
    {
        public static string ProductLink(this UrlHelper urlHelper, Guid productId, string slug = "")
        {
            if (string.IsNullOrEmpty(slug))
            {
                throw new ArgumentNullException(nameof(slug));
            }

            if (productId == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(productId));
            }

            return urlHelper.RouteUrl(RouteConstants.ProductDetail, new { id = productId, slug }, urlHelper.RequestContext.HttpContext.Request.Url.Scheme);
        }
    }
}