using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class Intelli : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                     if (HttpContext.Current.User.Identity.Name == "")
                      {
                        Response.Redirect("LogOut");
                      }
                     else
                     {
                         int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                         User m_UserDetails = new User().GetUserDetails(UserID);

                         if (m_UserDetails == null)
                         {
                             Response.Redirect("LogOut");
                         }
                         else
                         {
                             //update user subscription 
                             new UserSubscriptionDetails().UpdateSubscriptionStatus(UserID);

                             string _Scripts = "";
                             List<string> _LoadCss = new List<string>();
                             _LoadCss.Add("web\\css\\criteria");
                             _LoadCss.Add("web\\css\\master");
                             _LoadCss.Add("css\\intelliwindow");

                             List<string> _LoadMessages = new List<string>();
                             _LoadMessages.Add("LOGIN");

                             List<string> _LoadJs = new List<string>();

                             _LoadJs.Add("Scripts\\js_fun");
                             _LoadJs.Add("Scripts\\intelliwindow");
                             _LoadJs.Add("Scripts\\keyboard");
                             _LoadJs.Add("web\\js\\master");

                             string photoRootPath = System.Configuration.ConfigurationManager.AppSettings["PhotosRootUrl"].ToString();
                             _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                             _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                             _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _ThisUserID =\"" + UserID.ToString() + "\"</script>";
                             _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _PhotoRootUrl =\"" + photoRootPath + "\"</script>";
                             ltScripts.Text = _Scripts;
                         }
                     }                        
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}