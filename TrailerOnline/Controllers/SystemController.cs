using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.Models;

namespace TrailerOnline.Controllers
{
    public class SystemController : Controller
    {

        public ActionResult Common()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            return View(model);
        }

    }
}
