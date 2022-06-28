using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

using Newtonsoft.Json;

namespace MMC.Helper.Filter
{
    public class ActionLoggerFilter : IAsyncActionFilter
    {
        private readonly ILogger<ActionLoggerFilter> _logger;
        private readonly IHostingEnvironment _webHostEnvironment;

        public ActionLoggerFilter(ILogger<ActionLoggerFilter> logger,
                                           IHostingEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
            if (XmlComment.Navigators.Count == 0)
                XmlComment.LoadAll();
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var methodInfo = (context.ActionDescriptor as Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)?.MethodInfo;
            var desc = XmlComment.GetMethodComment(methodInfo);
            var request = JsonConvert.SerializeObject(context.ActionArguments.Values);
            _logger.LogInformation($"服务名称：{_webHostEnvironment.ApplicationName}，{desc}，请求参数json:{request}");

            await next();

            var result = JsonConvert.SerializeObject(JsonConvert.SerializeObject((await next?.Invoke())?.Result));
            _logger.LogInformation($"服务名称：{_webHostEnvironment.ApplicationName}，{desc}，请求参数json:{request}，响应参数json：{result}");
        }
    }
}
