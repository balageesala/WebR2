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
    public partial class rightrematch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string _Scripts = "";
                    List<string> _LoadCss = new List<string>();
                    _LoadCss.Add("web/css/passport");
                    _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                    ltScripts.Text = _Scripts;
                    SetMatchp();
                }
                catch (Exception)
                {

                }
            }
        }
        private void SetMatchp()
        {
            try
            {
                string _Overallp = string.Empty;
                string _Criteriap = string.Empty;
                string _Questionsp = string.Empty;
                int OtherUserID = 0;
                if (Request.QueryString["OtherUserID"] != null)
                {
                    OtherUserID = Convert.ToInt32(Request.QueryString["OtherUserID"]);
                    int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();

                    _Questionsp = new QuestionsMatchPercentage().GetMatchPercentage(_UserID, OtherUserID).ToString();
                    _Criteriap = new CriteriaMatchPercentage().GetMatchPercentage(_UserID, OtherUserID).ToString();
                    _Overallp = new QuestionsMatch().GetOverallMatchPercentage(_UserID, OtherUserID).ToString();

                    if (_Overallp != "-1")
                    {
                        lblOverallp.InnerText = _Overallp + "%";
                        lblOverall.Attributes.Add("style", "width:" + _Overallp + "%");
                    }
                    else
                    {
                        lblOverallp.InnerText = "?";
                        lblOverall.Attributes.Add("style", "width:0%");
                    }

                    if (_Criteriap != "-1")
                    {
                        lblCriteriap.InnerText = _Criteriap + "%";
                        lblCriteria.Attributes.Add("style", "width:" + _Criteriap + "%");
                    }
                    else
                    {
                        lblCriteriap.InnerText = "?";
                        lblCriteria.Attributes.Add("style", "width:0%");
                    }

                    if (_Questionsp != "-1")
                    {
                        lblQuestionsp.InnerText = _Questionsp + "%";
                        lblQuestions.Attributes.Add("style", "width:" + _Questionsp + "%");
                    }
                    else
                    {
                        lblQuestionsp.InnerText = "?";
                        lblQuestions.Attributes.Add("style", "width:0%");
                    }


                    // User Info
                    User OtherUserDetails = new User().GetUserDetails(OtherUserID);
                    divUserName.InnerText = OtherUserDetails.LoginName + " rematched you";
                    imgOtherProfilePic.Alt = OtherUserDetails.LoginName;
                    if (OtherUserDetails.ProfilePhoto != null)
                    {
                        imgOtherProfilePic.Src = new Utils().GetPhotoPCTPath(OtherUserDetails.ProfilePhoto.PhotoID, Page.Request);
                  
                    }
                    else
                    {
                        if (OtherUserDetails.Gender == 1)
                        {
                            imgOtherProfilePic.Src = SitePath + "web/images/M.png";
                        }
                        else
                        {
                            imgOtherProfilePic.Src = SitePath + "web/images/F.png";
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