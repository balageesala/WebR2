using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntellidateR1Web.web.inner
{
    public partial class thisdaymatch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";

                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\load-image.min");
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                ltScripts.Text = _Scripts;
                //re set matchp
                GetTodaysMatch();

            }
        }

        private void GetTodaysMatch()
        {
            string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                UserTodayMatch m_TodaysMatch = new UserTodayMatch().GetThisDayUserMatch(UserID);
                if (m_TodaysMatch != null)
                {
                    TodaysMatchLoad(m_TodaysMatch);
                }
                else
                {
                    divTodayMatchNotFound.Visible = false;
                    divTodayMatch.Visible = false;

                    if (DateTime.Now.Hour < 12)
                    {
                        divNewUserBefore12.Visible = true;
                        divNewUserAfter12.Visible = false;
                    }
                    else
                    {
                        divNewUserAfter12.Visible = true;
                        divNewUserBefore12.Visible = false;
                    }
                }

            }
            catch (Exception)
            {

            }
        }


        private void TodaysMatchLoad(UserTodayMatch m_TodaysMatch)
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                if (m_TodaysMatch == null)
                {
                    // Show not found
                    divTodayMatchNotFound.Visible = true;
                    divTodayMatch.Visible = false;
                }
                else
                {

                    if (m_TodaysMatch.UserID == UserID)
                    {

                        if (m_TodaysMatch.MatchUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoFullViewPath(m_TodaysMatch.MatchUser.ProfilePhoto.PhotoID, Page.Request);
                            string _Script = "<script type=\"text/javascript\"> var _MatchUserPhoto = \"" + _MatchUserPhoto + "\"; </script>";
                            ltScripts.Text = ltScripts.Text + _Script;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_TodaysMatch.MatchUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            string _Script = "<script type=\"text/javascript\"> var _MatchUserPhoto= \"" + _DefaultUserPhoto + "\"; </script>";
                            ltScripts.Text = ltScripts.Text + _Script;
                        }
                        lblTodaysMatchName.InnerText = m_TodaysMatch.MatchUser.LoginName;
                        lblTodaysMatchName.Attributes.Add("data-loginname", m_TodaysMatch.MatchUser.LoginName);
                        lblTodaysMatchName.Attributes.Add("data-loginid", m_TodaysMatch.MatchUser.UserID.ToString());
                        divTodaysMatchImage.Attributes.Add("data-loginname", m_TodaysMatch.MatchUser.LoginName);

                        lblTodaysMatchInfo.InnerText = "";

                        imgOverallMatch.Src = SitePath + "web/service/OverallMatchImage?o=y&p=" + m_TodaysMatch.OverallMatchPercentage.ToString();
                        imgOverallMatch.Attributes.Add("data-loginname", m_TodaysMatch.MatchUser.LoginName);

                        imgCriteriaMatch.Src = SitePath + "web/service/OverallMatchImage?p=" + m_TodaysMatch.CriteriaMatchPercentage.ToString();
                        imgCriteriaMatch.Attributes.Add("data-loginname", m_TodaysMatch.MatchUser.LoginName);
                        imgCriteriaMatch.Attributes.Add("data-matchp", m_TodaysMatch.CriteriaMatchPercentage.ToString());

                        imgPhilosophyMatch.Src = SitePath + "web/service/OverallMatchImage?p=" + m_TodaysMatch.PhilosophyMatchPercentage.ToString();
                        imgPhilosophyMatch.Attributes.Add("data-loginname", m_TodaysMatch.MatchUser.LoginName);
                        imgPhilosophyMatch.Attributes.Add("data-matchp", m_TodaysMatch.PhilosophyMatchPercentage.ToString());
                    }
                    else
                    {


                        if (m_TodaysMatch.ThisUser.ProfilePhoto != null)
                        {
                            string _MatchUserPhoto = new Utils().GetPhotoFullViewPath(m_TodaysMatch.ThisUser.ProfilePhoto.PhotoID, Page.Request);
                            string _Script = "<script type=\"text/javascript\"> var _MatchUserPhoto = \"" + _MatchUserPhoto + "\"; </script>";
                            ltScripts.Text = ltScripts.Text + _Script;

                        }
                        else
                        {
                            string _DefaultUserPhoto = string.Empty;
                            if (m_TodaysMatch.ThisUser.Gender == 1)
                            {
                                _DefaultUserPhoto = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                _DefaultUserPhoto = SitePath + "web/images/F.png";
                            }
                            string _Script = "<script type=\"text/javascript\"> var _MatchUserPhoto= \"" + _DefaultUserPhoto + "\"; </script>";
                            ltScripts.Text = ltScripts.Text + _Script;
                        }
                        lblTodaysMatchName.InnerText = m_TodaysMatch.ThisUser.LoginName;
                        lblTodaysMatchName.Attributes.Add("data-loginname", m_TodaysMatch.ThisUser.LoginName);
                        lblTodaysMatchName.Attributes.Add("data-loginid", m_TodaysMatch.ThisUser.UserID.ToString());
                        divTodaysMatchImage.Attributes.Add("data-loginname", m_TodaysMatch.ThisUser.LoginName);
                        lblTodaysMatchInfo.InnerText = "";
                        imgOverallMatch.Src = SitePath + "web/service/OverallMatchImage?o=y&p=" + m_TodaysMatch.OverallMatchPercentage.ToString();
                        imgOverallMatch.Attributes.Add("data-loginname", m_TodaysMatch.ThisUser.LoginName);
                        imgCriteriaMatch.Src = SitePath + "web/service/OverallMatchImage?p=" + m_TodaysMatch.CriteriaMatchPercentage.ToString();
                        imgCriteriaMatch.Attributes.Add("data-loginname", m_TodaysMatch.ThisUser.LoginName);
                        imgCriteriaMatch.Attributes.Add("data-matchp", m_TodaysMatch.CriteriaMatchPercentage.ToString());
                        imgPhilosophyMatch.Src = SitePath + "web/service/OverallMatchImage?p=" + m_TodaysMatch.PhilosophyMatchPercentage.ToString();
                        imgPhilosophyMatch.Attributes.Add("data-loginname", m_TodaysMatch.ThisUser.LoginName);
                        imgPhilosophyMatch.Attributes.Add("data-matchp", m_TodaysMatch.PhilosophyMatchPercentage.ToString());

                    }

                }

            }
            catch (Exception)
            {

            }
        }

    }
}