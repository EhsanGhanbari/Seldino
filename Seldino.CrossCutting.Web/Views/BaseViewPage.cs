using System.Web.Mvc;
using Seldino.CrossCutting.Authentication;

namespace Seldino.CrossCutting.Web.Views
{
    public abstract class BaseViewPage : WebViewPage
    {
        public virtual CustomPrincipal CurrentUser => base.User as CustomPrincipal;
    }

    public abstract class BaseViewPage<TModel> : WebViewPage<TModel>
    {
        public virtual CustomPrincipal CurrentUser => base.User as CustomPrincipal;
    }
}
