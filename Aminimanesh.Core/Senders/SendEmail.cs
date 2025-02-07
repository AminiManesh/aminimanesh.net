using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace ElectronicLearn.Core.Senders
{
    public class SendEmail
    {
        public static void Send(string to,string subject,string body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("mail.aminimanesh.ir");
            mail.From = new MailAddress("info@aminimanesh.ir", "aminimanesh.ir | امینی منش");
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("info@aminimanesh.ir", "@Googooli1381");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}