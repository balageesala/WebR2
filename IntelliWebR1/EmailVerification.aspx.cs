using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;
using System.Web.Security;

namespace IntelliWebR1
{
    public partial class EmailVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                if (Request.QueryString["em"] != null && Request.QueryString["dt"] != null)
                {
                    //make user log out here
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

                            // Crack the Cookie open
                            var formsAuthenticationTicket = FormsAuthentication.Decrypt(authenticationCookie.Value);

                            HttpCookie intellidateCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(formsAuthenticationTicket));
                            intellidateCookie.Expires = DateTime.Now.AddYears(-1);
                            Response.Cookies.Add(intellidateCookie);
                        }
                    }
                    catch (Exception)
                    {

                    }
                    string EmailAddress = Request.QueryString["em"].ToString();

                    DateTime _SendDate = Convert.ToDateTime(Request.QueryString["dt"].ToString());

                    DateTime _ExpiredDate = _SendDate.AddHours(24);

                    DateTime _TodayDate = DateTime.Now;

                    //email verification only done with in one day

                    if (_TodayDate <= _ExpiredDate)
                    {
                        IntellidateR1.User _User = new IntellidateR1.User().GetUserDetails(EmailAddress,true);
                        bool m_UpdateEmailVerification = new UserAccountSettings().SetUserEmailVerification(_User.UserID, EmailAddress);
                        if (m_UpdateEmailVerification)
                        {
                            divMessage.InnerText = "Your email verification successfully completed.";
                        }
                        else
                        {
                            divMessage.InnerText = "Your email verification link is expired.";
                        }
                    }
                    else
                    {
                        divMessage.InnerText = "Your email verification link is expired.";
                    }
                  
                }


                string _Scripts = "";
                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("css\\default");
                _LoadCss.Add("css\\intelliwindow");
                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                ltScripts.Text = _Scripts;
            }

        }
    }
}