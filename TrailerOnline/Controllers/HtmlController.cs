using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL;
using TrailerOnline.BLL.BusinessObjects;
using TrailerOnline.BLL.MultiTenancy;

namespace TrailerOnline.Controllers
{
    public class HtmlController : Controller
    {
        /// <summary>
        /// Displays html
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Index(int Id)
        {
            TenantBO tenant = TenantBLL.GetTenant(System.Web.HttpContext.Current);
            HtmlBO model = HtmlBLL.GetHtml(Id, tenant.TenantId);
            return PartialView(model);
        }

    }
}
