using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.Filters;

namespace TrailerOnline.Controllers
{

    [TenantAuthorization]
    public class MyAccountController : Controller
    {


        public ActionResult Settings()
        {
            return View();
        }


        public ActionResult Payments()
        {
            return View();
        }

        /*
        public ActionResult Profile()
        {
            return View();
        }*/

    }
}
