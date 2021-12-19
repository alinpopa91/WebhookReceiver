using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Flipdish.Recruiting.WebhookReceiver.DAL.Models;
using System.Collections.Generic;
using Flipdish.Recruiting.WebhookReceiver.BLL.Services.Email;
using Flipdish.Recruiting.WebhookReceiver.BLL.Services.WebHookService;
using Flipdish.Recruiting.WebhookReceiver.BLL.Exceptions;
using Flipdish.Recruiting.WebhookReceiver.BLL.Settings;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Flipdish.Recruiting.WebhookReceiver
{
    public static class WebhookReceiver
    {
        private static IWebHookService webHookService = new WebHookService();

        [FunctionName("WebhookReceiver")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log,
            ExecutionContext context)
        {
            try
            {
                var res = await webHookService.Process(req, log, context.FunctionAppDirectory);
                return new ContentResult { Content = res, ContentType = "text/html" };
            }
            catch (CustomException)
            {
                return new NotFoundResult();
            }
            catch (Exception)
            {
                return new UnauthorizedResult();
            }
        }
    }
}
