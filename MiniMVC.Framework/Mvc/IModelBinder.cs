using MiniMVC.Framework.Controller;
using System;

namespace MiniMVC.Framework.Mvc
{
    public interface IModelBinder
    {
        /// <summary>
        /// ASP.net mvc将这个机制成为Model的绑定
        /// </summary>
        /// <param name="controllerContext">ControllerContext</param>
        /// <param name="modelName">Model名称（这里实际上是参数名称）</param>
        /// <param name="modelType"></param>
        /// <returns></returns>
        object BindModel(ControllerContext controllerContext, string modelName, Type modelType);
    }
}
