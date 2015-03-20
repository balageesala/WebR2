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
    public partial class MatchProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _queryString = HttpContext.Current.Request.RawUrl;
                string m_SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                if (_queryString.IndexOf('?') != -1)
                {
                    try
                    {
                        string _Scripts = string.Empty;
                        string _hideTabNames = string.Empty;
                        string _otherUserName = _queryString.Split('?')[1].ToString();
                        User _OtherUserDetails = new User().GetUserDetails(_otherUserName, false);
                        if (_OtherUserDetails != null)
                        {
                            int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                            UserTodayMatch[] m_UserTodayMatches = new UserTodayMatch().GetAllMatches(UserID);
                            UserTodayMatch[] _UserInBank = m_UserTodayMatches.Where(x => x.UserID == _OtherUserDetails.UserID || x.MatchUserID == _OtherUserDetails.UserID).ToArray();
                            if (_UserInBank != null)
                            {
                                if (_UserInBank.Count() == 0)
                                {
                                    Response.Redirect(m_SitePath + "web/PageNotFound");
                                }

                                if (_OtherUserDetails != null)
                                {
                                    if (UserID != _OtherUserDetails.UserID)
                                    {
                                        otheruserpic.OtherUserID = _OtherUserDetails.UserID;
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
                                else
                                {
                                    Response.Redirect(m_SitePath + "web/PageNotFound");
                                }
                            }
                            else
                            {
                                Response.Redirect(m_SitePath + "web/PageNotFound");
                            }
                        }
                        else
                        {
                            Response.Redirect(m_SitePath + "web/PageNotFound");
                        }
                           
                    }
                    catch (Exception)
                    {
                        Response.Redirect(m_SitePath + "web/PageNotFound");
                    }
                }

            }
        }
    }
}