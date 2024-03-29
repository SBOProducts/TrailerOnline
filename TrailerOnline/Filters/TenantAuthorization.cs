﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrailerOnline.BLL.MultiTenancy;

namespace TrailerOnline.Filters
{
    public class TenantAuthorization: AuthorizeAttribute, IAuthorizationFilter
    {

        /// <summary>
        /// Prevents anyone other than the tenant from accessing an action on a controller. 
        /// </summary>
        /// <param name="filterContext"></param>
        /// <remarks>
        /// This does not stop Tenant A accessing Tenant B's data within their own form
        /// This does stop Tenant A from getting to Tenant B's form
        /// </remarks>
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            System.Security.Principal.IPrincipal user = HttpContext.Current.User;

            if (!user.Identity.IsAuthenticated)
                throw new UnauthorizedAccessException();

            TenantBO tenant = TenantBLL.GetTenant(HttpContext.Current);
            bool isOwner = tenant.IsOwner(user.Identity.Name);

            if (!isOwner)
                throw new UnauthorizedAccessException();
        }

    }
}