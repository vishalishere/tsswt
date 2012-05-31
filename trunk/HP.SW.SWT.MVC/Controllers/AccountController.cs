using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

using HP.SW.SWT.Extensions;
using HP.SW.SWT.MVC.Models;
using System.Net;
using System.IO;
using System.Text;

namespace HP.SW.SWT.MVC.Controllers
{
    [HandleError]
    public class AccountController : Controller
    {
        public IFormsAuthenticationService FormsService { get; set; }
        public IMembershipService MembershipService { get; set; }

        protected override void Initialize(RequestContext requestContext)
        {
            if (FormsService == null) { FormsService = new FormsAuthenticationService(); }
            if (MembershipService == null) { MembershipService = new AccountMembershipService(); }

            base.Initialize(requestContext);
        }

        // **************************************
        // URL: /Account/Unauthorized
        // **************************************
        public ActionResult Unauthorized(string originalUrl)
        {
            WebResponse response = null;
            string title = string.Empty;

            //try
            //{
            //    if (string.IsNullOrEmpty(Request.ServerVariables["HTTPS"]))
            //    {
            //        title = "http://";
            //    }
            //    else
            //    {
            //        title = "https://";
            //    }

            //    title += Request.ServerVariables["SERVER_NAME"] + ":" + Request.ServerVariables["SERVER_PORT"] + originalUrl;

            //    WebRequest request = WebRequest.Create(title);
            //    request.Credentials = new NetworkCredential("superuser", "super_user10");
            //    request.Timeout = Int32.MaxValue;

            //    response = request.GetResponse();
            //    Stream streamReceive = response.GetResponseStream();
            //    Encoding encoding = System.Text.Encoding.GetEncoding("utf-8");
            //    StreamReader streamRead = new System.IO.StreamReader(streamReceive, encoding);

            //    string html = streamRead.ReadToEnd();
            //    string[] htmlParts = html.ToLowerInvariant().Split(new string[] { "<title>", "</title>" }, StringSplitOptions.RemoveEmptyEntries);

            //    if (htmlParts.Length > 1)
            //    {
            //        title = htmlParts[1];
            //    }
            //}
            //catch (Exception)
            //{
            //    if (string.IsNullOrEmpty(title))
            //    {
                    title = originalUrl;
            //    }
            //}
            //finally
            //{
            //    if (response != null)
            //    {
            //        response.Close();
            //    }
            //}

            ViewData["OriginalUrl"] = originalUrl;
            ViewData["Title"] = title;
            return View();
        }

        // **************************************
        // URL: /Account/LogOn
        // **************************************
        public ActionResult LogOn()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Unauthorized", new { originalUrl = Request.QueryString["ReturnUrl"] });
            }
            return View();
        }

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ValidateUser(model.UserName, model.Password))
                {
                    FormsService.SignIn(model.UserName, model.RememberMe);
                    if (!String.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Usuario o clave incorrectos.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // **************************************
        // URL: /Account/LogOff
        // **************************************

        public ActionResult LogOff()
        {
            FormsService.SignOut();

            return RedirectToAction("Index", "Home");
        }

        // **************************************
        // URL: /Account/Register
        // **************************************

        public ActionResult Register()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus = MembershipService.CreateUser(model.UserName, model.Password, model.FullName);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsService.SignIn(model.UserName, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", AccountValidation.ErrorCodeToString(createStatus));
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePassword
        // **************************************

        [Authorize]
        public ActionResult ChangePassword()
        {
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                if (MembershipService.ChangePassword(User.Identity.Name, model.OldPassword, model.NewPassword))
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "La clave actual es incorrecta o la nueva clave es inválida.");
                }
            }

            // If we got this far, something failed, redisplay form
            ViewData["PasswordLength"] = MembershipService.MinPasswordLength;
            return View(model);
        }

        // **************************************
        // URL: /Account/ChangePasswordSuccess
        // **************************************

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

    }
}
