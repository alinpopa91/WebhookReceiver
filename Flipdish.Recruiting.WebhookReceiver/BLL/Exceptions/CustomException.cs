using System;
using System.Collections.Generic;
using System.Text;

namespace Flipdish.Recruiting.WebhookReceiver.BLL.Exceptions
{
    public class CustomException : Exception
    {
        public CustomException(string message, bool critical)
        {
            this.Message = message;
            this.ErrorLevel = critical ? "Critical" : "Warn";

        }
        public string Message { get; set; }
        public string ErrorLevel { get; set; }
    }
}
