using MiniMVC.Framework.Controller;
using System;
using System.Linq;
using System.Reflection;
using System.Web;

namespace MiniMVC.Framework.Mvc
{
    public class DefaultModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, string modelName, Type modelType)
        {
            if (modelType.IsValueType || modelType == typeof(string))
            {
                //如果参数类型为简单的值类型或者字符串，我们可以直接根据参数名称和key进行皮队
                object instance;
                if (GetValueTypeInstance(controllerContext, modelName, modelType, out instance))
                {
                    return instance;
                }
                return Activator.CreateInstance(modelType);
            }
            //对于复杂的类型，通过反射根据类型创建新的对象，并根据属性名称与key的匹配关系对应相应的属性进行赋值
            object modelInstance = Activator.CreateInstance(modelType);
            foreach (PropertyInfo property in modelType.GetProperties())
            {
                if (!property.CanWrite || (!property.PropertyType.IsValueType && property.PropertyType != typeof(string)))
                {
                    continue;
                }
                object propertyValue;
                if (GetValueTypeInstance(controllerContext, property.Name, property.PropertyType, out propertyValue))
                {
                    property.SetValue(modelInstance, propertyValue, null);
                }
            }
            return modelInstance;
        }
        private bool GetValueTypeInstance(ControllerContext controllerContext, string modelName, Type modelType, out object value)
        {
            var form = HttpContext.Current.Request.Form;
            string key;
            //绑定到参数上的数据来源：HTTP-POST Form
            if (form != null)
            {
                key = form.AllKeys.FirstOrDefault(k => string.Compare(k, modelName, true) == 0);
                if (key != null)
                {
                    value = Convert.ChangeType(form[key], modelType);
                    return true;
                }
            }
            //绑定到参数上的数据来源：RouteData的Values
            key = controllerContext.RequestContext.RouteData.Values.Where(item => string.Compare(item.Key, modelName, true) == 0)
                .Select(item => item.Key).FirstOrDefault();
            if (key != null)
            {
                value = Convert.ChangeType(controllerContext.RequestContext.RouteData.Values[key], modelType);
                return true;
            }
            //绑定到参数上的数据来源：RouteData的DataTokens
            key = controllerContext.RequestContext.RouteData.DataTokens.Where(item => string.Compare(item.Key, modelName, true) == 0)
                .Select(item => item.Key).FirstOrDefault();
            if (key != null)
            {
                value = Convert.ChangeType(controllerContext.RequestContext.RouteData.DataTokens[key], modelType);
                return true;
            }
            value = null;
            return false;
        }
    }
}
