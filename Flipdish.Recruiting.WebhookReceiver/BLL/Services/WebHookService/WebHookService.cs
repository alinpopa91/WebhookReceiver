using Flipdish.Recruiting.WebhookReceiver.BLL.Services.Email;
using Flipdish.Recruiting.WebhookReceiver.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Flipdish.Recruiting.WebhookReceiver.BLL.Exceptions;
using Flipdish.Recruiting.WebhookReceiver.BLL.Settings;

namespace Flipdish.Recruiting.WebhookReceiver.BLL.Services.WebHookService
{
    public class WebHookService : IWebHookService
    {
        public async Task<string> Process(HttpRequest req, ILogger log, string functionAppDirectory)
        {
            int? orderId = null;
            try
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
                OrderCreatedWebhook orderCreatedWebhook = await GetOrderFromRequest(req, functionAppDirectory);
                OrderCreatedEvent orderCreatedEvent = orderCreatedWebhook.Body;

                orderId = orderCreatedEvent.Order.OrderId;
                List<int> storeIds = new List<int>();
                string[] storeIdParams = req.Query["storeId"].ToArray();
                if (storeIdParams.Length > 0)
                {
                    storeIds = ParseArray(storeIdParams);
                    if (!storeIds.Contains(orderCreatedEvent.Order.Store.Id.Value))
                    {
                        throw new CustomException($"Skipping order #{orderId}", false);
                    }
                }

                Currency currency = GetCurrency(req.Query["currency"].ToString());
                var barcodeMetadataKey = req.Query["metadataKey"].First() ?? "eancode";

                string emailOrder = "";
                using (EmailRenderer emailRenderer = new EmailRenderer(orderCreatedEvent.Order, orderCreatedEvent.AppId, barcodeMetadataKey, functionAppDirectory, log, currency))
                {
                    emailOrder = emailRenderer.RenderEmailOrder();

                    try
                    {
                        await EmailService.Send(MailSettings.Mail, req.Query["to"], $"New Order #{orderId}", emailOrder, emailRenderer._imagesWithNames);
                    }
                    catch (Exception ex)
                    {
                        log.LogError($"Error occured during sending email for order #{orderId}" + ex);
                    }

                    log.LogInformation($"Email sent for order #{orderId}.", new { orderCreatedEvent.Order.OrderId });
                }


                return emailOrder;
            }
            catch (CustomException cex)
            {
                if (cex.ErrorLevel == "Critical")
                {
                    log.LogError($"Skipping order #{orderId}");
                }
                else
                {
                    log.LogInformation($"Skipping order #{orderId}");
                }
                throw cex;
            }
            catch (Exception ex)
            {
                log.LogError(ex, $"Error occured during processing order #{orderId}");
                throw ex;
            }
        }

        private async Task<OrderCreatedWebhook> GetOrderFromRequest(HttpRequest req, string functionAppDirectory)
        {
            OrderCreatedWebhook orderCreatedWebhook;

            string test = req.Query["test"];
            if (req.Method == "GET" && !string.IsNullOrEmpty(test))
            {

                var templateFilePath = Path.Combine(functionAppDirectory, "TestWebhooks", test);
                var testWebhookJson = new StreamReader(templateFilePath).ReadToEnd();

                orderCreatedWebhook = JsonConvert.DeserializeObject<OrderCreatedWebhook>(testWebhookJson);
            }
            else if (req.Method == "POST")
            {
                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                orderCreatedWebhook = JsonConvert.DeserializeObject<OrderCreatedWebhook>(requestBody);
            }
            else
            {
                throw new Exception("No body found or test param.");
            }

            return orderCreatedWebhook;
        }

        private List<int> ParseArray(string[] storeIdParams)
        {
            List<int> result = new List<int>();
            foreach (var storeIdString in storeIdParams)
            {
                int storeId = 0;
                try
                {
                    storeId = int.Parse(storeIdString);
                    result.Add(storeId);
                }
                catch (Exception) { }

            }

            return result;
        }

        private Currency GetCurrency(string currencyQuery)
        {
            if (string.IsNullOrEmpty(currencyQuery) || currencyQuery.Length < 3)
            {
                return Currency.EUR; //default
            }
            else
            {
                currencyQuery = currencyQuery.Substring(0, 3);
            }

            Currency currency = Currency.EUR;
            if (Enum.TryParse(typeof(Currency), currencyQuery.ToUpper(), out object currencyObject))
            {
                currency = (Currency)currencyObject;
            }
            else
            {
                throw new CustomException("Invalid currency", true);
            }

            return currency;
        }
    }
}
