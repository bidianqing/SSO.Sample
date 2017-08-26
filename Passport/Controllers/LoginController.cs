using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Passport.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoginDo(string returnUrl)
        {
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, "bidianqing", DateTime.UtcNow.AddHours(8), DateTime.UtcNow.AddHours(8).AddDays(30), true, "");
            string cookieValue = FormsAuthentication.Encrypt(ticket);
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieValue);
            cookie.Domain = FormsAuthentication.CookieDomain;
            cookie.Expires = DateTime.UtcNow.AddHours(8).AddDays(30);
            Response.Cookies.Add(cookie);
            if(string.IsNullOrEmpty(returnUrl))
            {
                returnUrl = "http://domain.dev";
            }
            return Redirect(returnUrl);
        }
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}