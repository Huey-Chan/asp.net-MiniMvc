using System.Web;

namespace MiniMVC.Framework.Route
{
    public interface IRouteHandler
    {
        /// <summary>
        /// 返回真正用于处理HTTP请求的HttpHandler对象
        /// </summary>
        /// <param name="requestContext">RequestContext表示当前（HTTP）请求的上下文</param>
        IHttpHandler GetHttpHandler(RequestContext requestContext);
    }
}
