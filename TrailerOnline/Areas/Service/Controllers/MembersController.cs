using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrailerOnline.Areas.Service.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {

        public ActionResult CreateWebsite()
        {
            return View();
        }



    }
}
