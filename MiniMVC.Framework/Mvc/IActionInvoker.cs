using MiniMVC.Framework.Controller;

namespace MiniMVC.Framework.Mvc
{
    /// <summary>
    /// Action的执行
    /// </summary>
    public interface IActionInvoker
    {
        /// <summary>
        /// 执行指定名称的Action方法
        /// </summary>
        /// <param name="controllerContext">表示基于当前Controller上下文的ControllerContext对象</param>
        /// <param name="actionName"></param>
        void InvokeAction(ControllerContext controllerContext, string actionName);
    }
}
