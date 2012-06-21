using System;
using System.Web.Mvc;
using System.Web.Security;

using HP.SW.SWT.Entities;

namespace HP.SW.SWT.MVC
{
    public class BaseController : Controller
    {
        protected User GetUser()
        {
            return Data.ADUser.GetByLogon(Membership.GetUser().UserName);
        }

        protected Resource GetUserAsResource()
        {
            User user = GetUser();
            Resource resource = Data.ADResource.Get(Membership.GetUser().UserName);

            if (resource == null)
            {
                Data.ADLogError.LogInfo(string.Format("El usuario {0} no existe como recurso.", Membership.GetUser().UserName), user);
            }
            else
            {
                Data.ADLogError.LogInfo(string.Format("El usuario {0} existe como recurso.", Membership.GetUser().UserName), user);
            }

            return resource;
        }

        protected JsonResult HandlePOSTError(Exception ex)
        {
            //invocar método para loggear el error en la tabla
            int id = Data.ADLogError.Log(ex, GetUser());
            return Json(new { result = "Error", message = ex.Message + "(" + id.ToString() +")"});
        }
    }
}