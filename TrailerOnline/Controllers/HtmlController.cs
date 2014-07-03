using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL;
using TrailerOnline.BLL.BusinessObjects;
using TrailerOnline.BLL.MultiTenancy;
using TrailerOnline.Filters;

namespace TrailerOnline.Controllers
{
    public class HtmlController : Controller
    {
        /// <summary>
        /// Displays html
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public ActionResult Index(Guid Id)
        {
            TenantBO tenant = TenantBLL.GetTenant(System.Web.HttpContext.Current);
            HtmlBO model = HtmlBLL.GetHtml(Id, tenant.TenantId);
            return PartialView(model);
        }

        [TenantAuthorization]
        [HttpPost]
        public ActionResult Save(Guid Id, string Html)
        {
            TenantBO tenant = TenantBLL.GetTenant(System.Web.HttpContext.Current);
            HtmlBO data = new HtmlBO() { Content = Html, HtmlId = Id, TenantId = tenant.TenantId };
            HtmlBLL.UpdateHtml(data);
            return Json(data);
        }

    }
}
