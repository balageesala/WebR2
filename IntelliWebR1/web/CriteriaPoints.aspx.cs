using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Text;

namespace IntelliWebR1.web
{
    public partial class CriteriaPoints : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    Response.Redirect("LogOut");
                }
                else
                {
                    IntellidateR1.Criteria[] _CriteriaQuestions = new IntellidateR1.Criteria().GetCriteriaList();
                    int _QuestionsCount = _CriteriaQuestions.Count();
                    int _ThisPageNo = _QuestionsCount + 1;
                    int _OutOfPages = _QuestionsCount + 2;
                    Numberleft.InnerText = _ThisPageNo.ToString();
                    NumberRight.InnerText = _OutOfPages.ToString();
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    IntellidateR1.CriteriaUserAnswerWeek[] _AnswredQuestions = new IntellidateR1.CriteriaUserAnswerWeek().GetCriteriaUserAnswers(UserID);
                  
                 //   decimal _TotalAssignedPoints = new IntellidateR1.CriteriaUserAnswerWeek().GetCreiteriaTotalAssignedPoints(UserID);
                    decimal _PointnsAssigned = 0;
                    foreach (CriteriaUserAnswerWeek _SingleAnswer in _AnswredQuestions)
                    {
                        _PointnsAssigned = _PointnsAssigned + _SingleAnswer.PointsAssigned;
                    }


                    decimal _UserAvilablePoints = Convert.ToDecimal(100 - _PointnsAssigned);

                    if (_UserAvilablePoints == 0)
                    {
                        Response.Redirect("Home");
                    }


                    AvilablePoints.InnerText = _UserAvilablePoints.ToString();
                    //bind avilable points here
                    StringBuilder _Sb = new StringBuilder();
                    _Sb.Append("<ul>");
                    foreach (CriteriaUserAnswerWeek _SingleAnswer in _AnswredQuestions)
                    {
                        bool HasUserAnswred = new CriteriaUserAnswerWeek().HasUserAnsweredCriteria(UserID, _SingleAnswer.Criteria_id);
                        if (HasUserAnswred)
                        {
                            _Sb.Append("<li class='boxes'>");
                            _Sb.Append("<p class='pointercss' id=" + _SingleAnswer.Criteria_id + ">" + _SingleAnswer.Criteria.CriteriaName + "</p>");
                            _Sb.Append("<input type='text' class='txtpoints' value='" + _SingleAnswer.PointsAssigned + "'  data-criteriaid='" + _SingleAnswer.Criteria_id + "' id='txt" + _SingleAnswer.Criteria_id + "' />");
                            _Sb.Append("<div class='clear'></div>");
                            _Sb.Append("</li>");
                        }
                        else
                        {
                            _Sb.Append("<li class='boxes'>");
                            _Sb.Append("<p class='pointercss' id=" + _SingleAnswer.Criteria_id + ">" + _SingleAnswer.Criteria.CriteriaName + "</p>");
                            _Sb.Append("<input type='text' class='txtpoints Disabled' disabled='disabled'  id='txt" + _SingleAnswer.Criteria_id + "' data-criteriaid=" + _SingleAnswer.Criteria_id + " value='" + _SingleAnswer.PointsAssigned + "' />");
                            _Sb.Append("<div class='clear'></div>");
                            _Sb.Append("</li>");
                        }
                       
                    }
                    _Sb.Append("</ul>");

                    divPoints.InnerHtml = _Sb.ToString();


                    User _GetUserDetails = new User().GetUserDetails(UserID);

                    bool IsUserPhoto = false;
                    if (_GetUserDetails.ProfilePhoto != null)
                    {
                        IsUserPhoto = true;
                    }
                    string _Scripts = string.Empty;
                    _Scripts = _Scripts + "\n<script type=\"text/javascript\">var _IsUserPhoto=\"" + IsUserPhoto + "\"</script>";
                    ltScripts.Text = _Scripts;


                }
            }
        }
    }
}