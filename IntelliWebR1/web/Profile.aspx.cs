using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntelliWebR1.web
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //_OtherUserID set in script
            //pass url like Profile?ramana#aboutme
            if (!Page.IsPostBack)
            {
                try
                {
                    string _queryString = HttpContext.Current.Request.RawUrl;
                    string m_SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                    if (_queryString.IndexOf('?') != -1)
                    {
                        string _Scripts = string.Empty;
                        string _hideTabNames = string.Empty;
                        string _otherUserName = _queryString.Split('?')[1].ToString();
                        User _OtherUserDetails = new User().GetUserDetails(_otherUserName, false);

                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                        if (_OtherUserDetails != null)
                        {
                            //check this user exist in 7 days(today's) match
                            bool m_IsUserWithInTodaysBank = new UserTodayMatch().IsUserWithInBank(UserID, _OtherUserDetails.UserID);

                            //check this user exist in 7 days rematch

                            bool m_IsUserWithInRematchBank = new ProfileRematch().IsMatchExistInBank(UserID, _OtherUserDetails.UserID);


                            if (!m_IsUserWithInTodaysBank && !m_IsUserWithInRematchBank)
                            {
                                Response.Redirect(m_SitePath + "web/PageNotFound");
                            }
                            else
                            {

                                if (UserID != _OtherUserDetails.UserID)
                                {
                                    _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _OtherUserID=\"" + _OtherUserDetails.UserID.ToString() + "\"</script>";
                                    _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _OtherUserGender=\"" + _OtherUserDetails.Gender.ToString() + "\"</script>";
                                    ltJScripts.Text = _Scripts;
                                    new IntellidateR1.ProfileView().AddNewProfileView(UserID, _OtherUserDetails.UserID);
                                }
                                else
                                {
                                    Response.Redirect(m_SitePath + "web/Home");
                                }
                            }
                        }
                        else
                        {
                            Response.Redirect(m_SitePath + "web/PageNotFound");
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}