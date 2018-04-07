using MiniMVC.Framework.Mvc;

namespace MiniMVC.Framework.Controller
{
    /// <summary>
    /// 为所有Controller定义了一个抽象基类
    /// </summary>
    public abstract class ControllerBase : IController
    {
        protected IActionInvoker ActionInvoker { get; set; }
        public ControllerBase()
        {
            this.ActionInvoker = new ControllerActionInvoker();
        }
        /// <summary>
        /// 核心是对于Action方法本身的执行和作为方法返回的ActionResult的执行
        /// 两者的执行是通过一个叫做ActionInvoker的组件来完成的
        /// </summary>
        /// <param name="requestContext"></param>
        public void Execute(RequestContext requestContext)
        {
            ControllerContext context = new ControllerContext { RequestContext = requestContext, Controller = this };
            //通过RequestContext中的RouteData得到目标Action的名称
            string actionName = requestContext.RouteData.ActionName;
            this.ActionInvoker.InvokeAction(context, actionName);
        }
    }
}
