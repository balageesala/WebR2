using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Web.Security;
using IntellidateR1;

namespace IntelliWebR1.web
{
    public partial class LogOut : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear all
            string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
            try
            {
                try
                {
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    new OnlineUsers().RemoveOnlineUser(UserID);
                    Session.Abandon();
                }
                catch (Exception)
                {

                }
                HttpRequest currentRequest = HttpContext.Current.Request;
                HttpCookie authenticationCookie = currentRequest.Cookies[FormsAuthentication.FormsCookieName];
                if (authenticationCookie != null)
                {

                    //  Crack the Cookie open
                    var formsAuthenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);

                    HttpCookie intellidateCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(formsAuthenticationTicket));
                    intellidateCookie.Expires = DateTime.Now.AddYears(-1);
                    Response.Cookies.Add(intellidateCookie);


                }
            }
            catch (Exception)
            {

            }
            FormsAuthentication.SignOut();
            Request.Cookies.Clear();
            Response.Redirect(SitePath + "Default");
        }
    }
}