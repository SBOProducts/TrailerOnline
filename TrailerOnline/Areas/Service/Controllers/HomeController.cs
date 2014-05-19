﻿using System;
using System.Collections.Generic;
using System.Linq;
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

        public ActionResult NotFound(string Id)
        {
            ViewBag.Tenant = Server.UrlDecode(Id);
            return View();
        }

    }
}
