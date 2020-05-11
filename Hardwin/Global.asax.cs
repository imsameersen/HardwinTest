using Hardwin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Hardwin
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_Error(object sender, EventArgs e)
        {
            var httpContext = ((HttpApplication)sender).Context;
            Exception exception = Server.GetLastError();
            Server.ClearError();
            var routeData = new RouteData();
            routeData.Values["controller"] = "Home";
            routeData.Values["action"] = "Error";
          
            using (var controller = new HomeController())
            {
                controller.ViewBag.Message = exception.Message;
                controller.ViewBag.StackTrace = exception.StackTrace;
                controller.ViewBag.Source = exception.Source;
                ((IController)controller).Execute(
                new RequestContext(new HttpContextWrapper(httpContext), routeData));

            }
        }
    }
}
