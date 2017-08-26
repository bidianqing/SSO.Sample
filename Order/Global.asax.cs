using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Order
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
        protected void Application_AuthenticateRequest(object sender,EventArgs e)
        {
            if(!Request.IsAuthenticated)
            {
                string url = Request.Url.AbsoluteUri;
                Response.Redirect(string.Concat("http://passport.domain.dev?returnUrl=", url));
            }
        }
    }
}
