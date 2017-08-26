using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Passport
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
            // 访问passport 发现已经登录，直接跳转到主站
            if(Request.IsAuthenticated)
            {
                Response.Redirect("http://domain.dev");
            }
        }
    }
}
