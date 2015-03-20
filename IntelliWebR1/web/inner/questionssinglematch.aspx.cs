using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class questionssinglematch : System.Web.UI.Page
    {
        public string SitePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                string _PhilosophyID = "";
                int _OtherUserID = Convert.ToInt32(Request.QueryString["uid"].ToString());


                if (Request.QueryString["dis"] != null)
                {
                    string _Discuss = Request.QueryString["dis"].ToString();
                    if (_Discuss == "1")
                    {
                        if (Request.QueryString["pid"] != null)
                        {
                            _PhilosophyID = Request.QueryString["pid"].ToString();
                        }
                        divDiscuss.Visible = true;
                        divDiscuss.Attributes.Add("class", "div" + _PhilosophyID);
                        string _DataUrl = SitePath + "web/inner/discusscompose?recid=" + _OtherUserID + "&pid=" + _PhilosophyID;
                        btnDiscuss.Attributes.Add("onclick", "LetDiscuss('" + _DataUrl + "');");
                       
                        string _Scripts = "";
                        _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _OtherUserID =\"" + _OtherUserID.ToString() + "\"</script>";
                        ltScripts.Text = _Scripts;


                    }
                }

                if (Request.QueryString["pid"] != null)
                {
                    _PhilosophyID = Request.QueryString["pid"].ToString();
                    LoadQuestionsMatch(_OtherUserID, _PhilosophyID);
                }
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatch(int OtherUserID, string PhilosophyID)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatches = new QuestionsMatch().GetQuestionsMatch(_UserID, OtherUserID, PhilosophyID);

                foreach (QuestionsMatch m_QuestionsMatch in m_QuestionsMatches)
                {
                    lblQuestion.InnerText = m_QuestionsMatch.QuestionName;

                    if (m_QuestionsMatch.User.ProfilePhoto != null)
                    {
                        imgUserIcon.Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.User.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (m_QuestionsMatch.User.Gender == 1)
                        {
                            imgUserIcon.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            imgUserIcon.Src = SitePath + "web/images/F.png";
                        }
                    }

                    if (m_QuestionsMatch.OtherUser.ProfilePhoto != null)
                    {
                        imgOtherUserIcon.Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.OtherUser.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (m_QuestionsMatch.OtherUser.Gender == 1)
                        {
                            imgOtherUserIcon.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            imgOtherUserIcon.Src = SitePath + "web/images/F.png";
                        }
                    }



                    // Answers

                    lblUserAnswer.InnerText = m_QuestionsMatch.UserValue;

                    //btnChatAboutIt.Attributes.Add("data-questionid", m_PhilosophyMatch.Philosophy_id);

                    if (m_QuestionsMatch.IsUserMatch == false)
                    {
                        lblUserAnswer.Attributes.Add("class", "redColor");
                    }

                    lblOtherUserAnswer.InnerText = m_QuestionsMatch.OtherUserValue;

                    if (m_QuestionsMatch.IsOtherUserMatch == false)
                    {
                        lblOtherUserAnswer.Attributes.Add("class", "redColor");
                    }

                    // Comments
                    if (m_QuestionsMatch.UserComment != "")
                        lblUserComment.InnerText = m_QuestionsMatch.UserComment;
                    else
                        lblUserComment.Visible = false;


                    if (m_QuestionsMatch.OtherUserComment != "")
                        lblOtherUserComment.InnerText = m_QuestionsMatch.OtherUserComment;
                    else
                        lblOtherUserComment.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }
    }
}