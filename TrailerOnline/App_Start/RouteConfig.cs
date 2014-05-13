using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TrailerOnline
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{tenant}/{controller}/{action}/{id}",
                defaults: new { tenant = TrailerOnline.BLL.MultiTenancy.TenantBLL.DefaultTenantName, controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            

        }
    }
}