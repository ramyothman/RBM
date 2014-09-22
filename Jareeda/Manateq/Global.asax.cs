using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace Manateq
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            RegisterRoutes(RouteTable.Routes);
        }

        public static void RegisterRoutes(RouteCollection routeCollection)
        {
            routeCollection.MapPageRoute("RouteForNews", "ns2-{Id}", "~/News/Default.aspx");
            routeCollection.MapPageRoute("RouteForColumnist", "columnist/cl8-{cl}", "~/Columnist/Default.aspx");
            routeCollection.MapPageRoute("RouteForColumn", "column/cl3-{Id}", "~/Columns/Default.aspx");
            routeCollection.MapPageRoute("RouteForForm", "form/6-{Id}", "~/Customer.aspx");
            routeCollection.MapPageRoute("RouteForSearch", "search/7-{key}", "~/Search/Default.aspx");
            routeCollection.MapPageRoute("RouteForNewsList", "list/5-{sections}", "~/News/List.aspx");
            //routeCollection.MapPageRoute("RouteForColumnistsList", "columnists/{Id}", "~/Customer.aspx");
            routeCollection.MapPageRoute("RouteForColumnsList", "customer/4-{Id}", "~/Customer.aspx");

            routeCollection.MapPageRoute("RouteForSections", "{sectionName}", "~/Default.aspx");
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}