﻿using System;
using System.Net;
using System.Net.Mail;
using System.Linq;
using SendGrid;
using SendGrid.SmtpApi;
using System.Net.Mime;
using System.Configuration;
using TrailerOnline.DAL.DAL.dbo;
using TrailerOnline.DAL.DO.dbo;

namespace TrailerOnline.BLL
{
    public class EmailBLL
    {
        #region Sending Email

        /// <summary>
        /// Sends an email
        /// </summary>
        /// <param name="FromAddress"></param>
        /// <param name="FromName"></param>
        /// <param name="ToAddress"></param>
        /// <param name="ToName"></param>
        /// <param name="Subject"></param>
        /// <param name="BodyHtml"></param>
        public static void Send(string FromAddress, string FromName, string ToAddress, string ToName, string Subject, string BodyHtml)
        {
            MailMessage mailMsg = new MailMessage();

            // to & from
            mailMsg.To.Add(new MailAddress(ToAddress, ToName));
            mailMsg.From = new MailAddress(FromAddress, FromName);

            // Subject and multipart/alternative Body
            mailMsg.Subject = Subject;
            mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(BodyHtml, null, MediaTypeNames.Text.Html));
            //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(BodyText, null, MediaTypeNames.Text.Plain));

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

        /// <summary>
        /// Sends an email from the default account to an email address where the person's name is known
        /// </summary>
        /// <param name="ToAddress"></param>
        /// <param name="ToName"></param>
        /// <param name="Subject"></param>
        /// <param name="BodyHtml"></param>
        public static void Send(string ToAddress, string ToName, string Subject, string BodyHtml)
        {
            string defaultFromAddress = ConfigurationManager.AppSettings["DefaultFromAddress"];
            string defaultFromName = ConfigurationManager.AppSettings["DefaultFromName"];
            Send(defaultFromAddress, defaultFromName, ToAddress, ToName, Subject, BodyHtml);
        }

        /// <summary>
        /// Sends an email from the default account to an email address where the person's name is not known
        /// </summary>
        /// <param name="ToAddress"></param>
        /// <param name="Subject"></param>
        /// <param name="BodyHtml"></param>
        public static void Send(string ToAddress, string Subject, string BodyHtml)
        {
            Send(ToAddress, "", Subject, BodyHtml);
        }

        #endregion

        #region Account Messages
        
        public class AccountMessages
        {
            /// <summary>
            /// Welcomes a new user and instructs them to confirm their account by clicking a link
            /// </summary>
            /// <param name="EmailAddress"></param>
            /// <param name="ConfirmationToken"></param>
            public static void ConfirmAccount(string EmailAddress, string ConfirmationToken)
            {
                TemplateDO template = Template.GetByTemplate_Name("ConfirmYourAccount").FirstOrDefault();
                string html = template.Content.Replace("#ConfirmationToken#", ConfirmationToken);
                Send(EmailAddress, "Welcome to Trailer Cloud", html);
            }

        }


        #endregion
    }
}
