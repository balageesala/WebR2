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
    public partial class theirpassport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["uid"] != null)
                {
                    try
                    {
                        int _OtherUserID = Convert.ToInt32(Request.QueryString["uid"]);
                        SetMatchp(_OtherUserID);
                    }
                    catch (Exception)
                    {
                     
                    }
                }
               

            }
        }


        private void SetMatchp(int OtherUserID)
        {
            try
            {
                string _Overallp = string.Empty;
                string _Criteriap = string.Empty;
                string _Questionsp = string.Empty;

                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();

                _Questionsp = new QuestionsMatchPercentage().GetMatchPercentage(_UserID, OtherUserID).ToString();
                _Criteriap = new CriteriaMatchPercentage().GetMatchPercentage(_UserID, OtherUserID).ToString();
                _Overallp = new QuestionsMatch().GetOverallMatchPercentage(_UserID, OtherUserID).ToString();

                if (_Overallp != "-1")
                {
                    liOverallPercentText.InnerText = _Overallp + "%";
                    OverallPercentWidth.Attributes.Add("style", "width:" + _Overallp + "%");
                }
                else
                {
                    liOverallPercentText.InnerText = "?";
                    OverallPercentWidth.Attributes.Add("style", "width:0%");
                }

                if (_Criteriap != "-1")
                {
                    liCriteriaPercentText.InnerText = _Criteriap + "%";
                    CriteriaPercentWidth.Attributes.Add("style", "width:" + _Criteriap + "%");
                }
                else
                {
                    liCriteriaPercentText.InnerText = "?";
                    CriteriaPercentWidth.Attributes.Add("style", "width:0%");
                }

                if (_Questionsp != "-1")
                {
                    liQuestionsPercentText.InnerText = _Questionsp + "%";
                    QuestionsPercentWidth.Attributes.Add("style", "width:" + _Questionsp + "%");
                }
                else
                {
                    liQuestionsPercentText.InnerText = "?";
                    QuestionsPercentWidth.Attributes.Add("style", "width:0%");
                }


                // User Info
                TempUser OtherUserDetails = new TempUser().GetUserDetails(OtherUserID);
                divUserName.InnerText = OtherUserDetails.LoginName;

                //get user last online time
                DateTime? _UserLastOnlineTime = new LoginDetails().GetUserLastLoginTime(OtherUserID);

                spnLastOnlineTime.InnerText = _UserLastOnlineTime.ToString();

                if (OtherUserDetails.ProfilePhoto != null)
                {
                    ImgProfilePicture.Src = new Utils().GetPhotoPCTPath(OtherUserDetails.ProfilePhoto.PhotoID, Page.Request);
                }
                else
                {
                    if (OtherUserDetails.Gender == 1)
                    {
                        ImgProfilePicture.Src = SitePath + "web/images/M.png";
                    }
                    else
                    {
                        ImgProfilePicture.Src = SitePath + "web/images/F.png";
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }




    }
}