using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace TrailerOnline.Areas.Service.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TestEmail()
        {
            try
            {
                MailMessage message = new MailMessage() { Subject = "testing email", Body = "This is just a test", IsBodyHtml = false };
                message.To.Add(new MailAddress("ntownsend2@mt.gov"));
                SmtpClient client = new SmtpClient();
                client.SendAsync(message, null);
                ViewBag.Message = "The email was sent";
            }
            catch (Exception ex)
            {
                ViewBag.Message = ex.Message;
            }
            return View();
        }

        public ActionResult NotFound(string Id)
        {
            ViewBag.Tenant = Server.UrlDecode(Id);
            return View();
        }

    }
}
