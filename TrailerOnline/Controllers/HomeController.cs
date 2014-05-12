using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL.MultiTenancy;

namespace TrailerOnline.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string url = Request.Url.ToString();
            string tenant = RouteData.Values["tenant"].ToString();
            TenantBO model = TenantBLL.GetTenant(tenant);

            return View(model);
        }


        public ActionResult Foundation()
        {
            return View();
        }
    }
}
