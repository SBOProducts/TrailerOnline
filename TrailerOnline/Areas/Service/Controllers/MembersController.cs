using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL;
using TrailerOnline.BLL.MultiTenancy;
using TrailerOnline.Models;

namespace TrailerOnline.Areas.Service.Controllers
{
    [Authorize]
    public class MembersController : Controller
    {



        [Authorize(Roles = RoleBLL.Tenant)]
        public ActionResult CreateWebsite()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = RoleBLL.Tenant)]
        public ActionResult CreateWebsite(CreateWebsiteModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                TenantBO tenant = TenantBLL.Create(model.TenantName, User.Identity.Name, model.BusinessName);
                return RedirectToAction("WebsiteCreated", "Account", new { id = tenant.TenantId });
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }
        }


        [Authorize(Roles = RoleBLL.Tenant)]
        public ActionResult WebsiteCreated(int Id)
        {
            TenantBO tenant = TenantBLL.GetTenantById(Id);
            return View(tenant);
        }



    }
}
