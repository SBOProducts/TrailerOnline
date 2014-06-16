using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL;

namespace TrailerOnline.Areas.Service.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            ViewBag.Location = Server.MachineName;
            return View();
        }

        


        public ActionResult NotFound(string Id)
        {
            ViewBag.Tenant = Server.UrlDecode(Id);
            return View();
        }

    }
}
