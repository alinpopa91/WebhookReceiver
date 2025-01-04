using System;
using System.Collections.Generic;
using System.Text;

namespace Flipdish.Recruiting.WebhookReceiver.BLL.Settings
{
    public static class MailSettings
    {
        public static string Mail = "test@gmail.com";
        public static string DisplayName = "Flipdesk Office";
        public static string Password = "test1";
        public static string Host = "smtp.gmail.com";
        public static int Port = 25;
        public static bool EnableSSL = false;
        public static bool UseDefaultCredentials = false;
        public static bool FakeSend = true;
    }
}
