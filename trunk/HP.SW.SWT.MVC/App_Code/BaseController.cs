using System;
using System.Web.Mvc;
using System.Web.Security;

using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC
{
    public class BaseController : Controller
    {
        public User GetUser()
        {
            return Data.ADUser.GetByLogon(Membership.GetUser().UserName);
        }

        public User GetUserById(int userId)
        {
            return Data.ADUser.Get(userId);
        }

        public Resource GetUserAsResource()
        {
            return Data.ADResource.Get(Membership.GetUser().UserName);
        }

        public JsonResult HandlePOSTError(Exception ex)
        {
            //invocar método para loggear el error en la tabla
            LogError logError = new LogError
            {
                Date = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace,
                User = GetUser()
            };

            int id = Data.ADLogError.Insert(logError);
            return Json(new { result = "Error", message = ex.Message + "(" + id.ToString() +")"});
        }
    }
}