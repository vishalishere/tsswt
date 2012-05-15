using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HP.SW.SWT.MVC.Scripts
{
    /// <summary>
    /// Summary description for server
    /// </summary>
    public class server : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            HttpRequest request = HttpContext.Current.Request;
            string baseUrl = string.Format("{0}://{1}{2}/", request.Url.Scheme, request.Url.Authority, request.ApplicationPath).TrimEnd('/');
            context.Response.Write("function root(url) { return '" + baseUrl + "' + url; }");
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