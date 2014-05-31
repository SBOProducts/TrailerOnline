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
        public EmailContentController(ControllerContext Context)
        {
            this.ControllerContext = Context;
        }

        /// <summary>
        /// Renders a view to string
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        public string RenderPartialViewToString(string viewName, object model)
        {
            string view = string.Format("~/Areas/Service/Views/EmailContent/{0}.cshtml", viewName);
            ViewData.Model = model;

            using (StringWriter sw = new StringWriter())
            {
                ViewEngineResult viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, view);
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
