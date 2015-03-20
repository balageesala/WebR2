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
    public partial class loadquestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["uid"] != null && Request.QueryString["qid"] != null)
                {
                    int OtherUserID = Convert.ToInt32(Request.QueryString["uid"]);
                    string Question_id = Request.QueryString["qid"].ToString();
                    LoadQuestionsMatch(OtherUserID, Question_id);
                }
            }
        }


        private void LoadQuestionsMatch(int OtherUserID, string Question_id)
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatches = new QuestionsMatch().GetQuestionsMatch(_UserID, OtherUserID, Question_id);

                foreach (QuestionsMatch m_QuestionsMatch in m_QuestionsMatches)
                {
                    hQuestion.InnerText = m_QuestionsMatch.QuestionName;

                    if (m_QuestionsMatch.User.ProfilePhoto != null)
                    {
                        imgUser.Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.User.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (m_QuestionsMatch.User.Gender == 1)
                        {
                            imgUser.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            imgUser.Src = SitePath + "web/images/F.png";
                        }
                    }

                    if (m_QuestionsMatch.OtherUser.ProfilePhoto != null)
                    {
                        imgOtherUser.Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.OtherUser.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (m_QuestionsMatch.OtherUser.Gender == 1)
                        {
                            imgOtherUser.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            imgOtherUser.Src = SitePath + "web/images/F.png";
                        }
                    }

                    // Answers

                    hUserAnswer.InnerText = m_QuestionsMatch.UserValue;

                    //btnChatAboutIt.Attributes.Add("data-questionid", m_PhilosophyMatch.Philosophy_id);

                    if (m_QuestionsMatch.IsUserMatch == false)
                    {
                        hUserAnswer.Attributes.Add("class", "redColor");
                    }

                    hOtherUserAnswer.InnerText = m_QuestionsMatch.OtherUserValue;

                    if (m_QuestionsMatch.IsOtherUserMatch == false)
                    {
                        hOtherUserAnswer.Attributes.Add("class", "redColor");
                    }

                    // Comments
                    if (m_QuestionsMatch.UserComment != "")
                        pUserComment.InnerText = m_QuestionsMatch.UserComment;
                    else
                        pUserComment.Visible = false;


                    if (m_QuestionsMatch.OtherUserComment != "")
                        pOtherUserComment.InnerText = m_QuestionsMatch.OtherUserComment;
                    else
                        pOtherUserComment.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }


    }
}