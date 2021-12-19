using Flipdish.Recruiting.WebhookReceiver.BLL.Exceptions;
using Flipdish.Recruiting.WebhookReceiver.BLL.Settings;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Flipdish.Recruiting.WebhookReceiver.BLL.Services.Email
{
    public class EmailService
    {
        public static async Task Send(string from, IEnumerable<string> to, string subject, string body, Dictionary<string, Stream> attachements, IEnumerable<string> cc = null)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                mailMessage.IsBodyHtml = true;
                mailMessage.From = new MailAddress(from);
                mailMessage.Subject = subject;
                mailMessage.Body = body;

                foreach (var t in to)
                {
                    mailMessage.To.Add(t);
                }

                if (cc != null)
                {
                    foreach (var t in cc)
                    {
                        mailMessage.To.Add(t);
                    }
                }
                foreach(var nameAndStreamPair in attachements)
                {
                    var attachment = new Attachment(nameAndStreamPair.Value, nameAndStreamPair.Key);
                    attachment.ContentId = nameAndStreamPair.Key;
                    mailMessage.Attachments.Add(attachment);
                }

                using (SmtpClient mailer = new SmtpClient(MailSettings.Host, MailSettings.Port))
                {
                    try
                    {
                        mailer.Host = MailSettings.Host;
                        mailer.Port = MailSettings.Port;
                        mailer.Credentials = new System.Net.NetworkCredential(MailSettings.Mail, MailSettings.Password);
                        mailer.UseDefaultCredentials = MailSettings.UseDefaultCredentials;
                        mailer.EnableSsl = MailSettings.EnableSSL;

                        if (!MailSettings.FakeSend)
                            await mailer.SendMailAsync(mailMessage);
                    }
                    catch (CustomException cex)
                    {
                        throw new CustomException("Unable to send email", false);
                    }

                };
                
            };
        }
    }
}
