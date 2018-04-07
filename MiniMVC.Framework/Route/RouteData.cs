using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMVC.Framework.Route
{
    /// <summary>
    /// 路由数据（路由表）
    /// </summary>
    public class RouteData
    {
        /// <summary>
        /// 代表直接从请求地址解析出来的变量列表
        /// </summary>
        public IDictionary<string, object> Values { get; private set; }
        /// <summary>
        /// 代表具有其他来源的变量列表
        /// </summary>
        public IDictionary<string, object> DataTokens { get; private set; }
        public IRouteHandler RouteHandler { get; set; }
        /// <summary>
        /// 生成路由数据对应的路由对象
        /// </summary>
        public RouteBase Route { get; set; }
        public RouteData()
        {
            this.Values = new Dictionary<string, object>();
            this.DataTokens = new Dictionary<string, object>();
            this.DataTokens.Add("namespaces", new List<string>());
        }
        public string Controller
        {
            get
            {
                object controllerName = string.Empty;
                //从请求地址解析Controller名称的同名属性，直接从Values字典中提取对应的Key为controller
                this.Values.TryGetValue("controller", out controllerName); 
                return controllerName.ToString();
            }
        }
        public string ActionName
        {
            get
            {
                object actionName = string.Empty;
                //从请求地址解析Action名称的同名属性，直接从Values字典中提取对应的Key为action
                this.Values.TryGetValue("action", out actionName);
                return actionName.ToString();
            }
        }
    }
}
