using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ForaTeknoloji.Common
{
    public class MailHelper
    {
        public static bool SendMail(string body, string to, string subject, string displayName, bool isHtml = true)
        {
            return SendMail(body, new List<string> { to }, subject, displayName, isHtml);
        }
        public static bool SendMail(string body, List<string> to, string subject, string displayName, bool isHtml = true)
        {
            bool result = false;
            try
            {
                var message = new MailMessage();
                message.From = new MailAddress(ConfigHelper.Get<string>("MailUser"), displayName);
                to.ForEach(x =>
                {
                    message.To.Add(new MailAddress(x));
                });
                message.Subject = "Kartlı Geçiş Kontrol Sistemi";
                message.Body = body;
                message.IsBodyHtml = isHtml;
                using (var smtp = new SmtpClient(ConfigHelper.Get<string>("MailHost"),
                    ConfigHelper.Get<int>("MailPort")))
                {
                    smtp.EnableSsl = true;
                    smtp.Credentials = new NetworkCredential(ConfigHelper.Get<string>("MailUser"), ConfigHelper.Get<string>("MailPass"));
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Send(message);
                    result = true;
                }


            }
            catch (Exception)
            {
            }

            return result;
        }
    }
}
