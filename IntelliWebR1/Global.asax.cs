using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace IntelliWebR1
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);


            RouteTable.Routes.MapPageRoute("RootRoute", "{Name}", "~/{Name}.aspx");
            RouteTable.Routes.MapPageRoute("InnerRoute", "inner/{Name}", "~/inner/{Name}.aspx");
            RouteTable.Routes.MapPageRoute("WebRoute", "web/{Name}", "~/web/{Name}.aspx");
            RouteTable.Routes.MapPageRoute("WebInnerRoute", "web/inner/{Name}", "~/web/inner/{Name}.aspx");
            RouteTable.Routes.MapPageRoute("PostRoute", "post/{Name}", "~/post/{Name}.aspx");

            RouteTable.Routes.MapPageRoute("ServiceRoute", "web/service/{Name}", "~/web/service/{Name}.aspx");

            RouteTable.Routes.MapPageRoute("JSRoute", "Scripts/{Name}.javascript", "~/Scripts/{Name}.aspx");

            RouteTable.Routes.MapPageRoute("IntelliRoute", "intelli/{Name}.date", "~/intelli/{Name}.aspx");


        }
    }
}
