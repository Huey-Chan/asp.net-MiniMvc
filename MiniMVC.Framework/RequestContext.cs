using MiniMVC.Framework.Route;
using System.Web;

namespace MiniMVC.Framework
{
    /// <summary>
    /// 当前（HTTP）请求的上下文，封装HttpContext和RouteData
    /// </summary>
    public class RequestContext
    {
        public virtual HttpContextBase HttpContext { get; set; }
        public virtual RouteData RouteData { get; set; }
    }
}
