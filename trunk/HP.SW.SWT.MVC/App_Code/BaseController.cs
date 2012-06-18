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

        public Resource GetUserAsResource()
        {
            return Data.ADResource.Get(Membership.GetUser().UserName);
        }
    }
}