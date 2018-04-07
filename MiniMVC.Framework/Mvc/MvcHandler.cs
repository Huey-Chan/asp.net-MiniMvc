using MiniMVC.Framework.Controller;
using System.Web;

namespace MiniMVC.Framework.Mvc
{
    public class MvcHandler : IHttpHandler
    {
        public bool IsReusable { get { return false; } }
        /// <summary>
        /// 当前请求上下文
        /// </summary>
        public RequestContext RequestContext { get; private set; }
        public MvcHandler(RequestContext requestContext)
        {
            this.RequestContext = requestContext;
        }
        public void ProcessRequest(HttpContext context)
        {
            string controllerName = this.RequestContext.RouteData.Controller;
            IControllerFactory controllerFactory = ControllerBuilder.Current.GetControllerFactory();
            //通过工厂模式激活Controller对象
            IController controller = controllerFactory.CreateController(this.RequestContext, controllerName);
            controller.Execute(this.RequestContext); //Controller对象的执行
        }
    }
}
