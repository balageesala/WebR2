using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class Notifications : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                User m_UserDetails = new User().GetUserDetails(UserID);
                if (m_UserDetails == null)
                {
                    Response.Redirect("LogOut");
                }
                else
                {
                    IntellidateR1.Notifications[] m_NotisList = new IntellidateR1.Notifications().GetUserNotifications(UserID);
                    if (m_NotisList.Count() > 0)
                    {

                        string _TimeToZone = "";
                        StringBuilder _Sb = new StringBuilder();
                        //add root div
                        _Sb.Append("<div class='notific fr'><input type='button' class='delete' id='btnDeleteAll' value='Delete' /></div><span class='clear'></span>");
                        _Sb.Append("<div class='notify_checkall fl'><label><input type='checkbox' id='chkSelectAll' /> Select all</label></div>");
                        _Sb.Append("<div class='notify_cont'>");
                        DateTime _RootDate = m_NotisList[0].TimeStamp.Date;
                        int Index = 0;
                        int _divEnd = 0;
                        foreach (IntellidateR1.Notifications _SingleNoti in m_NotisList)
                        {
                            if (Index == 0)
                            {
                                _Sb.Append(" <div class='notify_cont_block'> <div class='fr'><div class='kalam'>" + _RootDate.ToShortDateString() + "</div><span class='clear'></span></div><span class='clear'></span>");
                                _Sb.Append(" <div class='notify_cont_chat'>");
                                Index++;
                            }
                            else
                            {
                                if (_RootDate != _SingleNoti.TimeStamp.Date)
                                {
                                    _RootDate = _SingleNoti.TimeStamp.Date;
                                    _Sb.Append("</div></div>  <div class='notify_cont_block'> <div class='fr'><div class='kalam'>" + _RootDate.ToShortDateString() + "</div><span class='clear'></span></div><span class='clear'></span>");
                                    _Sb.Append(" <div class='notify_cont_chat'>");
                                }
                            }
                           
                            CultureInfo ci = new CultureInfo("en-US");
                            string date = _SingleNoti.TimeStamp.ToString("R", ci);
                            DateTime convertedDate = DateTime.Parse(date);
                            DateTime dt = TimeZone.CurrentTimeZone.ToLocalTime(convertedDate);
                          //  string TimeString = dt.ToShortTimeString();
                            _Sb.Append("<div class='div" + _SingleNoti.NotificationID + "'><div class='his_check'><input type='checkbox' class='chknotis' name='chksamll' data-id=" + _SingleNoti.NotificationID + " /></div>");

                            _Sb.Append(" <p>" + _SingleNoti.GetNotiText + " </p><small>" + dt.ToString("hh:mmtt").ToLower() + "</small>");
                            _Sb.Append(" <img src='images/bin-pic.jpg' class='imgDelete' alt=" + _SingleNoti.NotificationID + " /><span class='clear'></span></div>");
                        }
                        _Sb.Append("</div>");
                        _Sb.Append("</div>");
                        _Sb.Append("</div>");
                        DivNotifications.InnerHtml = _Sb.ToString();
                        string _Scripts = "";
                        _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _thistime =\"" + _TimeToZone + "\"</script>";
                        ltScripts.Text = _Scripts;


                        IntellidateR1.Notifications[] m_AllNotisList = new IntellidateR1.Notifications().GetUserAllNotifications(UserID);
                        foreach (var item in m_AllNotisList)
                        {
                            new IntellidateR1.Notifications().UpdateUserViewedNotification(item.NotificationID);
                        }
                    }
                    else
                    {
                        DivNotifications.InnerHtml = "Your notifications are empty.";
                    }

                }
            }
        }
    }
}