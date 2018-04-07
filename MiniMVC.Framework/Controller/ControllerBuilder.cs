using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMVC.Framework.Controller
{
    public class ControllerBuilder
    {
        private Func<IControllerFactory> factoryThunk;
        //表示当前ControllerBuilder的对象
        public static ControllerBuilder Current { get; private set; }
        static ControllerBuilder()
        {
            Current = new ControllerBuilder();
        }
        /// <summary>
        /// ControllerFactory的获取
        /// </summary>
        /// <returns></returns>
        public IControllerFactory GetControllerFactory()
        {
            return factoryThunk();
        }
        /// <summary>
        /// ControllerFactory的注册
        /// </summary>
        /// <param name="controllerFactory"></param>
        public void SetControllerFactory(IControllerFactory controllerFactory)
        {
            factoryThunk =
                () => { return controllerFactory; };
        }
    }
}
