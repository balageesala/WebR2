using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;

namespace IntellidateR1Web.web
{
    public partial class Intellidate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            if (HttpContext.Current.User.Identity.Name == "" || HttpContext.Current.User.Identity.Name == null )
            {
                try
                {
                    Response.Redirect("LogOut");
                }
                catch (Exception)
                {

                }

            }
            else
            {
                if (!Page.IsPostBack)
                {

                    try
                    {
                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                        User m_UserDetails = new User().GetUserDetails(UserID);

                        if (m_UserDetails == null)
                        {
                            Response.Redirect("LogOut");
                        }

                        //update user subscription 
                        new UserSubscriptionDetails().UpdateSubscriptionStatus(UserID);

                        string _Scripts = "";
                        List<string> _LoadCss = new List<string>();
                        _LoadCss.Add("web\\css\\intellidate");
                        _LoadCss.Add("web\\css\\chatwindows");
                        _LoadCss.Add("css\\intelliwindow");

                        List<string> _LoadMessages = new List<string>();
                        _LoadMessages.Add("LOGIN");
                        _LoadMessages.Add("REG");

                        List<string> _LoadJs = new List<string>();

                        //_LoadJs.Add("Scripts\\Sliderjquery-1.10.2");
                       // _LoadJs.Add("Scripts\\sliderjquery-ui");

                        _LoadJs.Add("Scripts\\js_fun");
                        _LoadJs.Add("Scripts\\intelliwindow");
                        _LoadJs.Add("Scripts\\keyboard");
                        _LoadJs.Add("Scripts\\intelliCheckbox");
                        _LoadJs.Add("web\\js\\master");
                        
                        
                        string photoRootPath = System.Configuration.ConfigurationManager.AppSettings["PhotosRootUrl"].ToString();
                        _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                        _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                        _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _ThisUserID =\"" + UserID.ToString() + "\"</script>";
                        _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _PhotoRootUrl =\"" + photoRootPath + "\"</script>";
                        ltScripts.Text = _Scripts;

                        string _CheckPageName = this.ContentPlaceHolder1.Page.GetType().FullName;

                        if (_CheckPageName.IndexOf("activateaccount") == -1)
                        {
                            string _UserStatus = ISUserActivated();
                            string _SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                            if (_UserStatus == "I")
                            {
                                Response.Redirect(_SitePath + "web/ActivateAccount");
                            }
                            if (_UserStatus == "E")
                            {
                                Response.Redirect(_SitePath + "web/LogOut");
                            }
                        }

                        UserTodayMatch[] m_UserTodayMatches = new UserTodayMatch().GetAllMatches(UserID);

                     

                        if (m_UserTodayMatches != null)
                        {

                            DateTime _LastDayRegistered = DateTime.Now.AddDays(-1);
                            DateTime _StartDate = new DateTime(_LastDayRegistered.Year, _LastDayRegistered.Month, _LastDayRegistered.Day, 0, 0, 0, 0);
                            DateTime _NoonDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 11, 59, 59, 999);

                            if (m_UserDetails.CreatedDate >= _StartDate && m_UserDetails.CreatedDate <= _NoonDate)
                            {
                                if (m_UserTodayMatches.Count() > 0)
                                {
                                    hdnNewUser.Value = "0";
                                }
                                else
                                {
                                    hdnNewUser.Value = "1";
                                }
                            }

                        }
                    }
                    catch (Exception)
                    {
                        
                       
                    }
                }
            }
        }

        public void MenuDisplay(bool ShowAllItems)
        {
            topmenustrip.ShowAllItems = ShowAllItems;
        }

        public void ContainerBoxDisplay(bool AddGrey)
        {
            if (AddGrey)
                divContainerBox.Attributes["class"] = "containerBox greyBack";
            else
                divContainerBox.Attributes["class"] = "containerBox";
        }

        public void HomeIConDisplay(bool IsDisplay)
        {
            if (IsDisplay)
               lnkHome.Visible=true;
            else
                lnkHome.Visible = false;
        }

        public void HomeIConDesable(bool IsDisplay)
        {
            if (IsDisplay)
            {
                lnkHome.HRef = "#";
                lnkHome.Attributes.Add("class", "desableHome");
            }
            else
            {
                lnkHome.HRef = "Home";
            }
                
        }



        public string ISUserActivated()
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool _res = new UserAccountSettings().ISUserActivated(UserID);
                if (_res)
                {
                    return "A";
                }
                else
                {
                    return "I";
                }
            }
            catch (Exception)
            {
                return "E";
            }
        }

       
    }
}