using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using HP.SW.SWT.Data;
using HP.SW.SWT.Entities;
using System.Text;

namespace HP.SW.SWT.MVC.Scripts
{
    /// <summary>
    /// Summary description for holiday
    /// </summary>
    public class holiday : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/javascript";

            context.Response.Write(ADHoliday.GetAll(DateTime.Now.Year).Aggregate("var holidays = [", ((x, y) => x + "'" + y.Date.ToString("yyyyMMdd") + "',")).TrimEnd(','));
            context.Response.Write("];");
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}