using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using IntellidateR1;

namespace IntelliWebR1.web.inner
{
    public partial class profilematchp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {          
                try
                {
                    Response.ContentType = "image/png";
                    string SitePath=ConfigurationManager.AppSettings["SitePath"].ToString();
                    if (Request.QueryString["OtherUserID"] != null && Request.QueryString["Type"] != null)
                    {
                        if (HttpContext.Current.User.Identity.Name != "")
                        {
                            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                            int OtherUserID = Convert.ToInt32(Request.QueryString["OtherUserID"]);

                            decimal _CriteriaMatch = new CriteriaMatchPercentage().GetMatchPercentage(_UserID, OtherUserID);
                            imgCriteriaTotal.Src = SitePath + "web/service/OverallMatchImage?p=" + _CriteriaMatch.ToString();

                            decimal _CriteriaTheyMatchYou = new CriteriaMatch()._GetCriteriaSinglePercentage(OtherUserID, _UserID);
                            imgCriteriaTheyMatchYou.Src = SitePath + "web/service/OverallMatchImage?p=" + _CriteriaTheyMatchYou.ToString();

                            decimal _CriteriaYouMatchThem = new CriteriaMatch()._GetCriteriaSinglePercentage(_UserID, OtherUserID);
                            imgCriteriaYouMatchThem.Src = SitePath + "web/service/OverallMatchImage?p=" + _CriteriaYouMatchThem.ToString();
                            

                            decimal _PhilosophyMatch = new QuestionsMatchPercentage().GetMatchPercentage(_UserID, OtherUserID);
                            imgPhilosophyTotal.Src = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyMatch.ToString();

                            decimal _PhilosophyTheyMatchYou = new QuestionsMatch()._GetQuestionsSinglePercentage(OtherUserID, _UserID);
                            imgPhilosophyTheyMatchYou.Src = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyTheyMatchYou.ToString();

                            decimal _PhilosophyYouMatchThem = new QuestionsMatch()._GetQuestionsSinglePercentage(_UserID, OtherUserID);
                            imgPhilosophyYouMatchThem.Src = SitePath + "web/service/OverallMatchImage?p=" + _PhilosophyYouMatchThem.ToString();


                            //bind userpics
                            User _GetUser = new User().GetUserDetails(_UserID);
                            User _GetOtherUser = new User().GetUserDetails(OtherUserID);

                            DivThisUserName.InnerHtml = _GetUser.LoginName;
                            DivOtherUserNane.InnerHtml = _GetOtherUser.LoginName;

                            if (_GetUser != null && _GetOtherUser != null)
                            {
                                if (_GetUser.ProfilePhoto != null)
                                {
                                    UserPic.Src = new Utils().GetPhotoPCTPath(_GetUser.ProfilePhoto.PhotoID, Page.Request);
                                }
                                else
                                {
                                    if (_GetUser.Gender == 1)
                                    {
                                        UserPic.Src = SitePath + "web/images/M.png";
                                    }
                                    else
                                    {
                                        UserPic.Src = SitePath + "web/images/F.png";
                                    }
                                }

                                if (_GetOtherUser.ProfilePhoto != null)
                                {
                                    OtherUserPic.Src = new Utils().GetPhotoPCTPath(_GetOtherUser.ProfilePhoto.PhotoID, Page.Request);
                                }
                                else
                                {
                                    if (_GetOtherUser.Gender == 1)
                                    {
                                        OtherUserPic.Src = SitePath + "web/images/M.png";
                                    }
                                    else
                                    {
                                        OtherUserPic.Src = SitePath + "web/images/F.png";
                                    }
                                }
                            }

                            //show and Hide criteria or questions

                            string _Type = Request.QueryString["Type"].ToString();
                            if (_Type == "c")
                            {
                                divCriteria.Visible = true;
                            }
                            else
                            {
                                divQuestions.Visible = true;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
           
        }
    }