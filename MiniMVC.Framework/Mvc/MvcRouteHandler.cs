using MiniMVC.Framework.Route;
using System.Web;

namespace MiniMVC.Framework.Mvc
{
    public class MvcRouteHandler : IRouteHandler
    {
        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            return new MvcHandler(requestContext);
        }
    }
}
