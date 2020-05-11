using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hardwin.Extensions
{
    public static class HtmlHelperExtesion
    {
        public static MvcHtmlString SubmitButton(this HtmlHelper htmlHelper, string value, string id, string className = null)
        {
            return new MvcHtmlString("<input type=\"submit\" value=" + value + " class=\"btn " + Convert.ToString(className) + "\"" + " />");
        }
      
    }
}