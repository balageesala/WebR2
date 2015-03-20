using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntelliWebR1.web.inner
{
    public partial class loadwritten : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Request.QueryString["wid"] != null)
                    {
                        int _WrittenAnswerID = Convert.ToInt32(Request.QueryString["wid"]);
                        DescriptionAnswers _Answer = new DescriptionAnswers().GetDescriptionAnswerAnsID(_WrittenAnswerID);
                        hWrittenQuestion.InnerText = _Answer.GetQuestion;
                        pWrittenAnswer.InnerText = _Answer.Answer;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}