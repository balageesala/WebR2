using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntelliWebR1.web.inner
{
    public partial class sexquestionsmatchp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                if (Request.QueryString["OtherUserID"] != null)
                {
                    divSexQuestions.Visible = true;
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    int OtherUserID = Convert.ToInt32(Request.QueryString["OtherUserID"]);
                    User _GetUser = new User().GetUserDetails(_UserID);
                    User _GetOtherUser = new User().GetUserDetails(OtherUserID);

                    if (_GetUser.Gender == 1)
                    {
                        DivPhilosophyOverall.Visible = true;
                        DivPhilosophyTheyMatchYou.Visible = false;
                        decimal _PhilosophyMatch = new QuestionsMatch().GetSexQuestionsOverallMatch(_UserID, OtherUserID);
                        if (_PhilosophyMatch == -1)
                        {
                            _PhilosophyMatch = 0;
                        }

                        imgSexPhilosophyTotal.Src = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyMatch.ToString();
                    }
                    else
                    {
                        DivPhilosophyTheyMatchYou.Visible = true;
                        DivPhilosophyOverall.Visible = false;
                        decimal _PhilosophyTheyMatchYou = new QuestionsMatch()._GetSexQuestionsSinglePercentage(OtherUserID, _UserID);
                        if (_PhilosophyTheyMatchYou == -1)
                        {
                            _PhilosophyTheyMatchYou = 0;
                        }
                        imgSexPhilosophyTheyMatchYou.Src = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyTheyMatchYou.ToString();
                    }
   
                   //bind userpics
                    lblOtherUserName.InnerHtml = _GetOtherUser.LoginName;
                    lblThisUserName.InnerHtml = _GetUser.LoginName;

                    if (_GetUser != null && _GetOtherUser != null)
                    {
                        if (_GetUser.ProfilePhoto != null)
                        {
                            UserSexPic.Src = new Utils().GetPhotoPCTPath(_GetUser.ProfilePhoto.PhotoID, Page.Request);
                        }
                        else
                        {
                            if (_GetUser.Gender == 1)
                            {
                                UserSexPic.Src = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                UserSexPic.Src = SitePath + "web/images/F.png";
                            }
                        }

                        if (_GetOtherUser.ProfilePhoto != null)
                        {
                            OtherSexUserPic.Src = new Utils().GetPhotoPCTPath(_GetOtherUser.ProfilePhoto.PhotoID, Page.Request);
                        }
                        else
                        {
                            if (_GetOtherUser.Gender == 1)
                            {
                                OtherSexUserPic.Src = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                OtherSexUserPic.Src = SitePath + "web/images/F.png";
                            }
                        }
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