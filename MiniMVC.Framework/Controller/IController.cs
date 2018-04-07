using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMVC.Framework.Controller
{
    public interface IController
    {
        void Execute(RequestContext requestContext);
    }
}
