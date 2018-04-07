using MiniMVC.Framework;
using MiniMVC.Framework.Controller;
using MiniMVC.Framework.Mvc;
using MiniMVC.Web.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniMVC.Web.Controllers
{
    public class HomeController : ControllerBase
    {
        public ActionResult Index(SimpleModel model)
        {
            string content = string.Format("Controller:{0}<br/>Action:{1}", model.Controller, model.Action);
            return new RawContentResult(content);
        }
    }
}