using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntelliWebR1.web.inner
{
    public partial class aboutmediscuss : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request.QueryString["wid"] != null)
                {
                    try
                    {
                        List<string> _LoadCss = new List<string>();
                        _LoadCss.Add("web\\css\\popups");
                        string _Scripts = "";
                        List<string> _LoadMessages = new List<string>();
                        List<string> _LoadJs = new List<string>();
                        _LoadJs.Add("Scripts\\js_fun");                    
                        _Scripts = _Scripts + Helper.LoadCSS(_LoadCss.ToArray());
                        _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);

                        ltScripts.Text = _Scripts;

                        int _AnswerID = Convert.ToInt32(Request.QueryString["wid"]);

                        DescriptionAnswers _Answer = new DescriptionAnswers().GetDescriptionAnswerAnsID(_AnswerID);
                        hQuestionText.InnerText = _Answer.GetQuestion;
                        pAnswer.InnerText = _Answer.Answer;
                        btnSubmit.Attributes.Add("data-mid", _Answer._id);
                        btnSubmit.Attributes.Add("data-sid", _Answer.AnswerID.ToString());
                    }
                    catch (Exception)
                    {
                        
                       
                    }
                }
            }
        }
    }
}