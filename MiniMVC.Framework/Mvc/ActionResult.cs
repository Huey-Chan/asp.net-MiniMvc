using MiniMVC.Framework.Controller;

namespace MiniMVC.Framework.Mvc
{
    public abstract class ActionResult
    {
        public abstract void ExecuteResult(ControllerContext context);
    }
}
