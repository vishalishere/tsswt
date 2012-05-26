using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HP.SW.SWT.Extensions
{
    public static class UrlHelperExtensions
    {
        public static string BaseUri(this UrlHelper urlHelper)
        {
            HttpRequest request = HttpContext.Current.Request;
            return string.Format("{0}://{1}{2}/", request.Url.Scheme, request.Url.Authority, request.ApplicationPath);
        }

        public static string Script(this UrlHelper urlHelper, string url)
        {
            return urlHelper.BaseUri().TrimEnd('/') + "/Scripts/" + url;
        }

        public static string Contents(this UrlHelper urlHelper, string url)
        {
            return urlHelper.BaseUri().TrimEnd('/') + "/Contents/" + url;
        }
    }
}