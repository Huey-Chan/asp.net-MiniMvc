using MiniMVC.Framework.Controller;
using MiniMVC.Framework.Mvc;

namespace MiniMVC.Framework
{
    /// <summary>
    /// 将初始化时指定的内容（字符串）原封不动的写入HTTP响应消息中
    /// </summary>
    public class RawContentResult : ActionResult
    {
        public string RawData { get; private set; }
        public RawContentResult(string rawData)
        {
            this.RawData = rawData;
        }
        /// <summary>
        /// 将初始化时指定的内容（字符串）原封不动的写入HTTP响应消息中
        /// </summary>
        /// <param name="context"></param>
        public override void ExecuteResult(ControllerContext context)
        {
            context.RequestContext.HttpContext.Response.Write(this.RawData);
        }
    }
}
