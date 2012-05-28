using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace HP.SW.SWT.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString DateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression)
        {
            return htmlHelper.DateBoxFor<TModel, TProperty>(expression, new Dictionary<string, object>());
        }

        public static MvcHtmlString DateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            htmlAttributes.Add("jType", "txtDatePicker");
            htmlAttributes.Add("style", "width: 70px;");
            htmlAttributes.Add("readonly", "readonly");
            return htmlHelper.TextBoxFor<TModel, TProperty>(expression, htmlAttributes);
        }

        public static MvcHtmlString DateBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            if (htmlAttributes is IDictionary<string, object>)
            {
                return htmlHelper.DateBoxFor<TModel, TProperty>(expression, (IDictionary<string, object>)htmlAttributes);
            }
            else if (htmlAttributes is string)
            {
                IDictionary<string, object> attributes = new Dictionary<string, object>();
                attributes.Add("value", htmlAttributes);
                return htmlHelper.DateBoxFor<TModel, TProperty>(expression, attributes);
            }
            else
            {
                throw new Exception("Invalid htmlAttributes Parameters");
            }
        }
    }
}
