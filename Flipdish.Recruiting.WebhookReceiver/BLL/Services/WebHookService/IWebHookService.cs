using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Flipdish.Recruiting.WebhookReceiver.BLL.Services.WebHookService
{
    public interface IWebHookService
    {
        Task<string> Process(HttpRequest req, ILogger log, string functionAppDirectory);
    }
}
