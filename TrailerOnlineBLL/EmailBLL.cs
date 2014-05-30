using System;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.SmtpApi;
using System.Net.Mime;
using System.Configuration;


namespace TrailerOnline.BLL
{
    public class EmailBLL
    {
        public static void Send(string FromAddress, string FromName, string ToAddress, string ToName, string Subject, string BodyHtml, string BodyText)
        {
            MailMessage mailMsg = new MailMessage();

            // to & from
            mailMsg.To.Add(new MailAddress(ToAddress, ToName));
            mailMsg.From = new MailAddress(FromAddress, FromName);

            // Subject and multipart/alternative Body
            mailMsg.Subject = Subject;
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(BodyHtml, null, MediaTypeNames.Text.Html));
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(BodyText, null, MediaTypeNames.Text.Plain));

            // Init SmtpClient and send
            string host = ConfigurationManager.AppSettings["SMTPHost"];
            int port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
            string login = ConfigurationManager.AppSettings["SMTPLogin"];
            string password = ConfigurationManager.AppSettings["SMTPPassword"];
            SmtpClient smtpClient = new SmtpClient(host, port);
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(login, password);
            smtpClient.Credentials = credentials;

            smtpClient.Send(mailMsg);
        }



    }
}
