using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TrailerOnline.Areas.Service.Controllers
{
    public class EmailContentController : Controller
    {
        /// <summary>
        /// Renders a view to string
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RenderPartialViewToString(string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.RouteData.GetRequiredString("action");

            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
                ViewContext viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }


        /// <summary>
        /// Generates the Account Confirmation email for users to click a link and confirm their account
        /// </summary>
        /// <param name="ConfirmationToken"></param>
        /// <returns></returns>
        public ActionResult AccountConfirmation(string ConfirmationToken)
        {
            return PartialView(ConfirmationToken);
        }

        

    }
}
