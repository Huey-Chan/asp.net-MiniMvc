using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace MiniMVC.Framework.Route
{
    public class UrlRoutingModule : IHttpModule
    {
        public void Dispose()
        { }
        public void Init(HttpApplication context)
        {
            context.PostResolveRequestCache += OnPostResolveRequestCache;
        }
        protected void OnPostResolveRequestCache(object sender, EventArgs e)
        {
            //HttpContextWrapper是HttpContext的子类
            HttpContextWrapper httpContext = new HttpContextWrapper(HttpContext.Current);
            //RouteTable的静态只读方法Routes得到表示全局路由表的RouteDictionary对象，
            //调用GetRouteData方法并传入用于封装当前HttpContext的HttpContextWrapper对象，
            //最终得到一个封装路由数据的RouteData对象
            RouteData routeData = RouteTable.Routes.GetRouteData(httpContext);
            if (routeData == null)
            {
                return;
            }
            RequestContext requestContext = new RequestContext { HttpContext = httpContext, RouteData = routeData };
            IHttpHandler handler = routeData.RouteHandler.GetHttpHandler(requestContext);
            httpContext.RemapHandler(handler); //用于当前的HTTP请求的处理
        }
    }
}
