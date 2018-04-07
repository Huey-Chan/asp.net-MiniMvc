using MiniMVC.Framework.Mvc;
using System.Collections.Generic;
using System.Web;

namespace MiniMVC.Framework.Route
{
    /// <summary>
    /// 基于URL模板的路由机制
    /// </summary>
    public class Route : RouteBase
    {
        /// <summary>
        /// 用于根据指定的请求上下文（通过一个RequestContext对象表示）来获取一个HttpHandler对象
        /// </summary>
        public IRouteHandler RouteHandler { get; set; }
        /// <summary>
        /// 代表URL模板的字符串
        /// </summary>
        public string Url { get; set; }
        public IDictionary<string, object> DataTokens { get; set; }
        public Route()
        {
            this.DataTokens = new Dictionary<string, object>();
            this.RouteHandler = new MvcRouteHandler(); //默认情况下Route的RouteHandler属性是一个MvcRouteHandler对象
        }
        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            IDictionary<string, object> variables;
            //HttpContextBase获取当前请求的URL
            if (this.Match(httpContext.Request.AppRelativeCurrentExecutionFilePath.Substring(2), out variables))
            {
                RouteData routeData = new RouteData();
                foreach (var item in variables)
                {
                    //Values属性表示的字典对象包含直接通过地址解析出来的变量
                    routeData.Values.Add(item.Key, item.Value);
                }
                foreach (var item in DataTokens)
                {
                    //DataTokens字典直接取自Route对象的同名属性
                    routeData.DataTokens.Add(item.Key, item.Value);
                }
                //当GetRouteData方法执行后，Route的RouteHandler属性值将反映在得到的RouteData的同名属性上
                routeData.RouteHandler = this.RouteHandler; 
                return routeData;
            }
            return null;
        }
        /// <summary>
        /// 判断当前请求的URL与URL模板的模式是否匹配
        /// </summary>
        /// <param name="requestUrl">HttpContextBase获取当前请求的URL</param>
        /// <param name="variables"></param>
        /// <returns>如果HttpContextBase获取当前请求的URL和URL模板的模式相匹配，创建一个RouteData返回，否则返回null</returns>
        protected bool Match(string requestUrl, out IDictionary<string, object> variables)
        {
            variables = new Dictionary<string, object>();
            string[] strArray1 = requestUrl.Split('/');
            string[] strArray2 = this.Url.Split('/');
            //如果HttpContextBase获取当前请求的URL和URL模板的模式相匹配，创建一个RouteData返回，否则返回null
            if (strArray1.Length != strArray2.Length)
            {
                return false;
            }
            for (int i = 0; i < strArray2.Length; i++)
            {
                if (strArray2[i].StartsWith("{") && strArray2[i].EndsWith("}"))
                {
                    variables.Add(strArray2[i].Trim("{}".ToCharArray()), strArray1[i]);
                }
            }
            return true;
        }
    }
}
