using System.Collections.Generic;
using System.Web;

namespace MiniMVC.Framework.Route
{
    /// <summary>
    /// 具名的路由对象的列表（Key表示路由对象的注册名称）
    /// </summary>
    public class RouteDictionary : Dictionary<string, RouteBase>
    {
        /// <summary>
        /// 遍历集合找到与指定的HttpContextBase对象匹配的路由对象
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns>RouteData路由数据</returns>
        public RouteData GetRouteData(HttpContextBase httpContext)
        {
            //遍历集合找到与指定的HttpContextBase对象匹配的路由对象
            foreach (var route in this.Values)
            {
                RouteData routeData = route.GetRouteData(httpContext);
                if (routeData != null)
                    return routeData; //返回RouteData
            }
            return null;
        }
    }
}
