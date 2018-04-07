using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMVC.Framework.Controller
{
    public interface IControllerFactory
    {
        IController CreateController(RequestContext requestContext, string controllerName);
    }
}
