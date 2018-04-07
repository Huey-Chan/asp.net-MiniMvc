
namespace MiniMVC.Framework.Route
{
    /// <summary>
    /// 路由表（多个路由对象RouteBase组成了一个路由表）
    /// </summary>
    public class RouteTable
    {
        /// <summary>
        /// 整个web应用的全局路由表
        /// </summary>
        public static RouteDictionary Routes { get; private set; }
        static RouteTable()
        {
            Routes = new RouteDictionary();
        }
    }
}
