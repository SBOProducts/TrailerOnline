using System;
using System.Net;
using System.Net.Mail;
using SendGrid;
using SendGrid.SmtpApi;
using System.Net.Mime;


namespace TrailerOnline.BLL
{
    public class EmailBLL
    {
        public static void Test()
        {

            try
            {
                MailMessage mailMsg = new MailMessage();

                // To
                mailMsg.To.Add(new MailAddress("ntownsend2@mt.gov", "Nathan Townsend"));

                // From
                mailMsg.From = new MailAddress("ntownsend2@gmail.com", "From Name");

                // Subject and multipart/alternative Body
                mailMsg.Subject = "subject";
                string text = "text body";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

                // Init SmtpClient and send
                SmtpClient smtpClient = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587));
                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("sboproducts", "snap01234");
                smtpClient.Credentials = credentials;

                smtpClient.Send(mailMsg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            /*

            var from = new MailAddress("john@contoso.com");
            var to   = new MailAddress[] { new MailAddress("ntownsend2@mt.gov") };
            var subject = "Testing";
            var html = "<p>Hello World in html</p>";
            var text = "Hello World plain text!";

            SendGridMessage message = new SendGridMessage(from, to, subject, html, text);
            
            */
        }
    }
}
