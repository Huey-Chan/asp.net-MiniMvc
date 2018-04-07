using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;

namespace MiniMVC.Framework.Controller
{
    /// <summary>
    /// 激活Controller
    /// </summary>
    public class DefaultControllerFactory : IControllerFactory
    {
        private static List<Type> controllerTypes = new List<Type>();
        static DefaultControllerFactory()
        {
            //通过BuildManager加载所有的引用的程序集
            foreach (Assembly assembly in BuildManager.GetReferencedAssemblies())
            {
                //得到所有实现了接口IController的类型并将其缓存起来
                foreach (Type type in assembly.GetTypes().Where(type => typeof(IController).IsAssignableFrom(type)))
                {
                    controllerTypes.Add(type);
                }
            }
        }
        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            //controllerName仅仅表示Controller的名称，我们需要加上Controller后缀才可以成为类型名称
            string typeName = controllerName + "Controller";
            //根据Controller的名称和命名空间从保存的controllerTypes中得到对应的Controller类型
            Type controllerType = controllerTypes.FirstOrDefault(c => string.Compare(typeName, c.Name, true) == 0);
            if (controllerType == null)
                return null;
            //通过反射的方式创建它
            return (IController)Activator.CreateInstance(controllerType);
        }
    }
}
