using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1.web.inner
{
    public partial class discusscompose : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {

                    string _Scripts = "";

                    List<string> _Loadcss = new List<string>();
                    _Loadcss.Add("web\\css\\popups");
                    _Scripts = _Scripts + "\n" + Helper.LoadCSS(_Loadcss.ToArray());

                    List<string> _LoadMessages = new List<string>();
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("web\\js\\discusscompose");
                   
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);
                    ltScripts.Text = _Scripts;

                    if (Request.QueryString["recid"] != null && Request.QueryString["pid"] != null)
                    {
                        string _OtherUserID = Request.QueryString["recid"].ToString();
                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                        string Question_Id = Request.QueryString["pid"].ToString();

                        if (_OtherUserID == "0")
                        {
                            divCanSend.Visible = false;
                            divCantSend.Visible = true;
                        }
                        else
                        {
                            LoadQuestionsMatch(Convert.ToInt32(_OtherUserID), Question_Id);
                            bool _IsUserAbleToCompose = new Conversation().IsUserAbleToSendSecoundMessage(UserID, Convert.ToInt32(_OtherUserID));
                            divCanSend.Visible = _IsUserAbleToCompose;
                            divCantSend.Visible = !_IsUserAbleToCompose;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void LoadQuestionsMatch(int OtherUserID, string PhilosophyID)
        {
            try
            {
                string  SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatches = new QuestionsMatch().GetQuestionsMatch(_UserID, OtherUserID, PhilosophyID);

                foreach (QuestionsMatch m_QuestionsMatch in m_QuestionsMatches)
                {
                    hQuestion.InnerText = m_QuestionsMatch.QuestionName;

                    if (m_QuestionsMatch.User.ProfilePhoto != null)
                    {
                        thisUserImg.Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.User.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (m_QuestionsMatch.User.Gender == 1)
                        {
                            thisUserImg.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            thisUserImg.Src = SitePath + "web/images/F.png";
                        }
                    }

                    if (m_QuestionsMatch.OtherUser.ProfilePhoto != null)
                    {
                        otherUserImg.Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.OtherUser.ProfilePhoto.PhotoID, Page.Request);
                    }
                    else
                    {
                        if (m_QuestionsMatch.OtherUser.Gender == 1)
                        {
                            otherUserImg.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            otherUserImg.Src = SitePath + "web/images/F.png";
                        }
                    }



                    // Answers

                    hThisAnswer.InnerText = m_QuestionsMatch.UserValue;

                    //btnChatAboutIt.Attributes.Add("data-questionid", m_PhilosophyMatch.Philosophy_id);

                    if (m_QuestionsMatch.IsUserMatch == false)
                    {
                        hThisAnswer.Attributes.Add("class", "redColor");
                    }

                    hOtherAnswer.InnerText = m_QuestionsMatch.OtherUserValue;

                    if (m_QuestionsMatch.IsOtherUserMatch == false)
                    {
                        hOtherAnswer.Attributes.Add("class", "redColor");
                    }

                    // Comments
                    if (m_QuestionsMatch.UserComment != "")
                        pThisComment.InnerText = m_QuestionsMatch.UserComment;
                    else
                        pThisComment.Visible = false;


                    if (m_QuestionsMatch.OtherUserComment != "")
                        pOtherComment.InnerText = m_QuestionsMatch.OtherUserComment;
                    else
                        pOtherComment.Visible = false;
                }
            }
            catch (Exception)
            {

            }
        }

    }
}