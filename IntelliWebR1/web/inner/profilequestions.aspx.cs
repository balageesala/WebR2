using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class profilequestions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int OtherUserID = 0;
            int LoadType = 0;
            bool loadPhilosphyQuestions = false;
            string _partOfQtnText = string.Empty;
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["u"] != null)
                {
                    OtherUserID = Convert.ToInt32(Request.QueryString["u"].ToString());

                    if (Request.QueryString["l"] != null)
                    {
                        LoadType = Convert.ToInt32(Request.QueryString["l"]);
                    }
                    if (Request.QueryString["qt"] != null)
                    {
                        _partOfQtnText = Request.QueryString["qt"].ToString();
                    }
                    divBothAnswered.Visible = true;
                    switch (LoadType)
                    {
                        case 0:
                            {
                                //LoadQuestionsMatchNormal(OtherUserID);  // The order in which they appear to me
                                LoadQuestionsMatchNormalOrderByRankOrder(OtherUserID);
                                break;
                            }
                        case 1:
                            {
                                LoadQuestionsMatchNormalOrderByOtherUser(OtherUserID);  // The order in which they appear to her
                                break;
                            }
                        case 2:
                            {
                                LoadQuestionsMatchOtherUserAnswerUnAcceptable(OtherUserID); // Her answers are unacceptable
                                break;
                            }
                        case 3:
                            {
                                LoadQuestionsMatchUserAnswerUnAcceptable(OtherUserID); // My answers are unacceptable
                                break;
                            }
                        case 4:
                            {
                                LoadQuestionsMatchBothAnswerUnAcceptable(OtherUserID); // Both of our answers are unacceptable
                                break;
                            }
                        case 5:
                            {
                                LoadQuestionsMatchBothAnswerAcceptable(OtherUserID); // We both agree
                                break;
                            }
                        case 7:
                            {
                                LoadQuestionsMatchWithComment(OtherUserID); // Answers with explanations
                                break;
                            }
                        case 6:
                            {
                                LoadQuestionsMatchUnAnsweredByMe(OtherUserID); // UnAnswered by me
                                break;
                            }

                        case 8:
                            {
                                LoadOnlySexQuestions(OtherUserID); // load sex questions only
                                break;
                            }
                        case 9:
                            {
                                LoadSearchQuestions(OtherUserID, _partOfQtnText); // load questions based on user text
                                hdnSearchText.Value = _partOfQtnText; 
                                // LoadQuestionsMatchNormalOrderByRankOrder(OtherUserID);
                                break;
                            }
                        default:
                            {
                                LoadQuestionsMatchNormalOrderByRankOrder(OtherUserID);
                                break;
                            }
                    }
                    LoadScripts(loadPhilosphyQuestions, OtherUserID, LoadType);
                    
                }
            }

        }


        private void LoadQuestionsMatchWithComment(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false ).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.OtherUserComment != "" || x.UserComment != "" && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssigned).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchUnAnsweredByMe(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue == "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssignedByOtherUser).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchUserAnswerUnAcceptable(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.IsUserMatch == false).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssigned).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchOtherUserAnswerUnAcceptable(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.IsOtherUserMatch == false && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssigned).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchBothAnswerUnAcceptable(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.IsOtherUserMatch == false && x.IsUserMatch == false && x.IsAnsweredPrivately == false).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssigned).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchBothAnswerAcceptable(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.IsOtherUserMatch == true && x.IsUserMatch == true && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssigned).ToArray();


                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchNormal(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssigned).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        private void LoadQuestionsMatchNormalOrderByOtherUser(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();

                m_QuestionsMatch = m_QuestionsMatch.OrderByDescending(x => x.PointsAssignedByOtherUser).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }



        private void LoadQuestionsMatchNormalOrderByRankOrder(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();

                QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>[] _Answers = new QuestionAnswers<OptionsSingleSelectAnswer, OptionsMultiSelectAnswer>().GetUserAnswers(OtherUserID);

                

                List<QuestionsMatch> lstQmatch = new List<QuestionsMatch>(); ;

                foreach (var _Answer in _Answers)
                {
                    QuestionsMatch _Match = new QuestionsMatch();
                    _Match = m_QuestionsMatch.Where(x => x.Question_id == _Answer.Question_id).SingleOrDefault();
                    //here QuestionType is rank order;
                    if (_Match != null)
                    {
                        if (!_Answer.AnsweredPrivately)
                        {
                            _Match.QuestionType = _Answer.RankOrder;
                            lstQmatch.Add(_Match);
                        }
                    }
                   
                }

                var _OrderByRankOrder = lstQmatch.OrderBy(x => x.QuestionType);

                rptPhilosophyMatch.DataSource = _OrderByRankOrder;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception)
            {

            }
        }

        public void LoadSearchQuestions(int OtherUserID, string EnteredText)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);
                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 0).ToArray();
                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.QuestionName.ToLower().Contains(EnteredText.ToLower())).ToArray();
                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
            }
            catch (Exception ex)
            {

            }
        }



        public void LoadOnlySexQuestions(int OtherUserID)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                QuestionsMatch[] m_QuestionsMatch = new QuestionsMatch().GetQuestionsMatch(UserID, OtherUserID);

                m_QuestionsMatch = m_QuestionsMatch.Where(x => x.UserValue != "" && x.OtherUserValue != "" && x.IsAnsweredPrivately == false && x.QuestionCategory == 1).ToArray();

                rptPhilosophyMatch.DataSource = m_QuestionsMatch;
                rptPhilosophyMatch.DataBind();
              //  divDropDown.Visible = false;
                hdnSubMenu.Value = "1";
              
            }
            catch (Exception ex)
            {

            }
        }

        private void LoadScripts(bool loadPhilosophy, int OtherUserID, int SelectedItem)
        {
            string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
            string _Scripts = "";
            _Scripts = _Scripts + "\n<script type=\"text/javascript\">var _ThisUserID=\"" + HttpContext.Current.User.Identity.Name + "\"</script>";
            _Scripts = _Scripts + "\n<script type=\"text/javascript\">var _OtherUserID=\"" + OtherUserID.ToString() + "\"</script>";
           _Scripts = _Scripts + "\n<script type=\"text/javascript\">var _SelectedItem=\"" + SelectedItem.ToString() + "\"</script>";

            ltScripts.Text = _Scripts;
        }

        protected void rptPhilosophyMatch_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string SitePath = "";
            try
            {
                SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();

                QuestionsMatch m_QuestionsMatch = (QuestionsMatch)e.Item.DataItem;
                ((HtmlGenericControl)e.Item.FindControl("lblQuestion")).InnerText = m_QuestionsMatch.QuestionName;
                HtmlAnchor _AnchorTag = (HtmlAnchor)e.Item.FindControl("BtnEditQtn");
                _AnchorTag.Attributes.Add("data-id", m_QuestionsMatch.Question_id);

                if (m_QuestionsMatch.User.ProfilePhoto != null)
                {
                  
                    ((HtmlImage)e.Item.FindControl("imgUserIcon")).Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.User.ProfilePhoto.PhotoID, Page.Request);
                 
                }
                else
                {
                    if (m_QuestionsMatch.User.Gender == 1)
                    {
                        ((HtmlImage)e.Item.FindControl("imgUserIcon")).Src = SitePath + "web/images/M.png";
                    }
                    else
                    {
                        ((HtmlImage)e.Item.FindControl("imgUserIcon")).Src = SitePath + "web/images/F.png";
                    }
                }


                if (m_QuestionsMatch.OtherUser.ProfilePhoto != null)
                {

                    ((HtmlImage)e.Item.FindControl("imgOtherUserIcon")).Src = new Utils().GetPhotoPCTPath(m_QuestionsMatch.OtherUser.ProfilePhoto.PhotoID, Page.Request);
                }
                else
                {
                    if (m_QuestionsMatch.OtherUser.Gender == 1)
                    {
                        ((HtmlImage)e.Item.FindControl("imgOtherUserIcon")).Src = SitePath + "web/images/M.png";
                    }
                    else
                    {
                        ((HtmlImage)e.Item.FindControl("imgOtherUserIcon")).Src = SitePath + "web/images/F.png";
                    }
                }



                // Answers

                ((HtmlGenericControl)e.Item.FindControl("lblUserAnswer")).InnerText = m_QuestionsMatch.UserValue;


                string _Url = "";
                _Url = SitePath + "web/inner/discusscompose?recid=" + m_QuestionsMatch.OtherUserID.ToString() + "&pid=" + m_QuestionsMatch.Question_id;
                ((HtmlImage)e.Item.FindControl("btnChatAboutIt")).Attributes.Add("data-url", _Url);




                if (m_QuestionsMatch.IsUserMatch == false)
                {
                    ((HtmlGenericControl)e.Item.FindControl("lblUserAnswer")).Attributes.Add("class", "redColor");
                }

                ((HtmlGenericControl)e.Item.FindControl("lblOtherUserAnswer")).InnerText = m_QuestionsMatch.OtherUserValue;

                if (m_QuestionsMatch.IsOtherUserMatch == false)
                {
                    ((HtmlGenericControl)e.Item.FindControl("lblOtherUserAnswer")).Attributes.Add("class", "redColor");
                }

                // Comments
                if (m_QuestionsMatch.UserComment != "")
                    ((HtmlGenericControl)e.Item.FindControl("lblUserComment")).InnerText = m_QuestionsMatch.UserComment;
                else
                    ((HtmlGenericControl)e.Item.FindControl("lblUserComment")).Visible = false;


                if (m_QuestionsMatch.OtherUserComment != "")
                    ((HtmlGenericControl)e.Item.FindControl("lblOtherUserComment")).InnerText = m_QuestionsMatch.OtherUserComment;
                else
                    ((HtmlGenericControl)e.Item.FindControl("lblOtherUserComment")).Visible = false;




                if (m_QuestionsMatch.UserValue == "" && m_QuestionsMatch.QuestionCategory == 0)
                {
                    ((Panel)e.Item.FindControl("pnlAnswered")).Visible = false;
                    ((Panel)e.Item.FindControl("pnlSexQuestions")).Visible = false;
                    ((Panel)e.Item.FindControl("pnlNotAnswered")).Visible = true;
                    ((HtmlGenericControl)e.Item.FindControl("divLoadMatch")).Attributes.Add("class","cls" + m_QuestionsMatch.Question_id);

                    ((HtmlGenericControl)e.Item.FindControl("lblQuestionText")).InnerText = m_QuestionsMatch.QuestionName;
                    string m_EditQtnUrl = SitePath + "web/inner/answerquestion?qid=" + m_QuestionsMatch.Question_id;
                    ((HyperLink)e.Item.FindControl("lnkAnswerQuestion")).Attributes.Add("data-url", m_EditQtnUrl);
                }
                if (m_QuestionsMatch.QuestionCategory == 1)
                {
                    ((Panel)e.Item.FindControl("pnlAnswered")).Visible = false;
                    ((Panel)e.Item.FindControl("pnlNotAnswered")).Visible = false;
                    ((Panel)e.Item.FindControl("pnlSexQuestions")).Visible = true;
                    ((HtmlGenericControl)e.Item.FindControl("lblSexQuestionText")).InnerText = m_QuestionsMatch.QuestionName;
                }


            }
            catch (Exception)
            {

            }
        }





    }
}