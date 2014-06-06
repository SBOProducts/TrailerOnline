using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using TrailerOnline.BLL;
using TrailerOnline.BLL.MultiTenancy;
using TrailerOnline.Models;
using WebMatrix.WebData;

namespace TrailerOnline.Areas.Service.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

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

        #region Login


        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            // if user exists but not confirmed take to verify account page
            if (WebSecurity.UserExists(model.UserName) && !WebSecurity.IsConfirmed(model.UserName))
                return RedirectToAction("VerifyAccount");

            // try to login
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
            {
                return RedirectToAction("CreateWebsite", "Members");
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction("Index", "Home");
        }

        
        /// <summary>
        /// A helper method that directs the user to the return url
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        #endregion


        #region Password Reset

        public ActionResult RequestPasswordReset()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RequestPasswordReset(ResendVerificationEmailModel model)
        {
            // valid input?
            if (!ModelState.IsValid)
                return View(model);

            // account exists?
            if (!WebSecurity.UserExists(model.EmailAddress))
            {
                ModelState.AddModelError("", "An account with that email address could not be found");
                return View(model);
            }

            string token = WebSecurity.GeneratePasswordResetToken(model.EmailAddress);
            EmailBLL.AccountMessages.PasswordResetRequest(model.EmailAddress, token);
            return RedirectToAction("PasswordResetSent", "Account");
        }


        public ActionResult PasswordResetSent()
        {
            return View();
        }

        public ActionResult UpdatePassword(string id)
        {
            ResetPasswordModel model = new ResetPasswordModel() { ResetToken = id };
            return View(model);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult UpdatePassword(ResetPasswordModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            bool successful = WebSecurity.ResetPassword(model.ResetToken, model.Password);
            if (successful)
                return RedirectToAction("PasswordUpdated", "Account");

            ModelState.AddModelError("", "Password reset failed.");
            return View(model);
            


            
        }


        public ActionResult PasswordUpdated()
        {
            return View();
        }

        #endregion

        #region Registration

        /// <summary>
        /// Confirms that the account has been verified
        /// </summary>
        /// <returns></returns>
        public ActionResult AccountVerified()
        {
            return View();
        }


            /// <summary>
        /// Used to determine if a website is available or not
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult CheckWebsiteName(string name)
        {
            if (name.Trim().Length < 4)
                throw new Exception("too short");

            string host = string.Format("{0}.{1}", name, TenantBLL.DefaultHost);
            return Json(TenantBLL.TenantExistsByHost(host));
        }

        /// <summary>
        /// Shows a form for registering an account
        /// </summary>
        /// <returns></returns>
        public ActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// Creates a new registration from the submitted information
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // register unconfirmed account
                    string ConfirmationToken = WebSecurity.CreateUserAndAccount(model.UserName, model.Password, requireConfirmationToken: true);
                    Roles.AddUserToRole(model.UserName, RoleBLL.Tenant);

                    //string ConfirmationToken = "test";

                    // send welcome / confirmation email
                    EmailBLL.AccountMessages.ConfirmAccount(model.UserName, ConfirmationToken);

                    // take to the verify account page
                    return RedirectToAction("VerifyAccount", "Account");
                }
                catch (MembershipCreateUserException e)
                {
                    ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                }
                catch (DuplicateTenantException e)
                {
                    ModelState.AddModelError("", e.Message);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }


        /// <summary>
        /// Sends a new verification email
        /// </summary>
        /// <returns></returns>
        public ActionResult ResendVerificationEmail()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ResendVerificationEmail(ResendVerificationEmailModel model)
        {
            // form is valid?
            if (!ModelState.IsValid)
                return View(model);
            
            try{

                // account exists?
                if (!WebSecurity.UserExists(model.EmailAddress))
                {
                    ModelState.AddModelError("", "An account with that email address could not be found. Please check the email address.");
                    return View();
                }

                // is confirmed already?
                if (WebSecurity.IsConfirmed(model.EmailAddress))
                {
                    ModelState.AddModelError("", "This account has already been confirmed");
                    return View();
                }
                
                int userId = WebSecurity.GetUserId(model.EmailAddress);

                // ok, send a new email
                using (UsersContext db = new UsersContext())
                {
                    // the only way to get the token is to query the db directly, WebSecurity didn't think of that for some reason...
                    string sql = string.Format("select ConfirmationToken from webpages_Membership where UserId={0}", userId);
                    string token = db.Database.SqlQuery<string>(sql).FirstOrDefault();
                    EmailBLL.AccountMessages.ConfirmAccount(model.EmailAddress, token);
                    return RedirectToAction("VerifyAccount");
                }
                

            
            } catch(Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View();
            }

            
            

        }




        /// <summary>
        /// Provides a form for the user to verify their account
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyAccount(string id)
        {

            // if the token wasn't specified then return the view
            if (string.IsNullOrEmpty(id))
                return View();

            // if the token isn't correct then inform them
            if (!WebSecurity.ConfirmAccount(id))
            {
                ViewBag.Message = "The security token is invalid. Please try again by using the button below.";
                return View();
            }

            // lookup the user by confirmation token and send emails to user and system admin
            try
            {
                // lookup email
                string userEmail = string.Empty;
                using (UsersContext db = new UsersContext())
                {
                    int UserId = db.Database.SqlQuery<int>(string.Format("select UserId from webpages_Membership where ConfirmationToken = '{0}'", id)).FirstOrDefault();
                    UserProfile profile = db.UserProfiles.Where(p => p.UserId == UserId).FirstOrDefault();
                    userEmail = profile.UserName;
                }

                // send message if found
                if (!string.IsNullOrEmpty(userEmail))
                {
                    EmailBLL.AccountMessages.AccountConfirmed(userEmail);
                    EmailBLL.AccountMessages.NewAccountNotification(userEmail);
                }
            }
            catch { }
            
            // if the account is confirmed then show verified
            return RedirectToAction("AccountVerified", "Account");
        }


        /// <summary>
        /// Provides friendly messages for errors encountered during registration
        /// </summary>
        /// <param name="createStatus"></param>
        /// <returns></returns>
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }

        #endregion
    }
}
