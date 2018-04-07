using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMVC.Framework.Controller
{
    /// <summary>
    /// 表示对当前的Controller和请求上下文的封装
    /// </summary>
    public class ControllerContext
    {
        /// <summary>
        /// 当前的Controller
        /// </summary>
        public ControllerBase Controller { get; set; }
        /// <summary>
        /// 请求上下文
        /// </summary>
        public RequestContext RequestContext { get; set; }
    }
}
