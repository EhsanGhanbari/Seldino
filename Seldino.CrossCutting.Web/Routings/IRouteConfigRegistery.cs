
using System.Web.Routing;

namespace Seldino.CrossCutting.Web.Routings
{
    public interface IRouteConfigRegistery
    {
        void Register(RouteCollection routes);

        int Priority { get; }
    }
}
