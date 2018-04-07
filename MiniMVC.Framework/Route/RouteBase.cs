using System.Web;

namespace MiniMVC.Framework.Route
{
    /// <summary>
    /// 生成路由数据对应的路由对象
    /// </summary>
    public abstract class RouteBase
    {
        /// <summary>
        /// 判断是否与当前请求匹配
        /// </summary>
        /// <param name="httpContext">当前HTTP上下文的HttpContextBase对象</param>
        /// <returns>匹配情况下返回封装路由数据的RouteData，不匹配返回null</returns>
        public abstract RouteData GetRouteData(HttpContextBase httpContext);
    }
}
