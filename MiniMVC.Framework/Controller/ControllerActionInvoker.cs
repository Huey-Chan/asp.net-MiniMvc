using MiniMVC.Framework.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MiniMVC.Framework.Controller
{
    public class ControllerActionInvoker : IActionInvoker
    {
        public IModelBinder ModelBinder { get; private set; }
        public ControllerActionInvoker()
        {
            this.ModelBinder = new DefaultModelBinder();
        }
        /// <summary>
        /// 实现针对Action方法的执行
        /// </summary>
        /// <param name="controllerContext"></param>
        /// <param name="actionName"></param>
        public void InvokeAction(ControllerContext controllerContext, string actionName)
        {
            //将Action名称作为方法名从Controller类型中得到表示Action草自拍的MethodInfo对象
            MethodInfo method = controllerContext.Controller.GetType().GetMethods().First(m => string.Compare(actionName, m.Name, true) == 0);
            List<object> parameters = new List<object>();
            //由于Action方法具有相应的参数，在执行Action方法之前必须进行参数的绑定。
            //遍历MethodInfo的参数列表
            foreach (ParameterInfo parameter in method.GetParameters())
            {
                //对于每一个ParameterInfo对象，将它的Name参数名称和ParameterType类型还有ControllerContext调用BindModel方法得到对应的参数值
                parameters.Add(this.ModelBinder.BindModel(controllerContext, parameter.Name, parameter.ParameterType));
            }
            //通过反射的方式传入参数列表并执行MethodInfo
            ActionResult actionResult = method.Invoke(controllerContext.Controller, parameters.ToArray()) as ActionResult;
            actionResult.ExecuteResult(controllerContext);
        }
    }
}
