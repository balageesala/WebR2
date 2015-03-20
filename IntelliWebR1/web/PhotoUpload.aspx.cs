using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class PhotoUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    IntellidateR1.Criteria[] _CriteriaQuestions = new IntellidateR1.Criteria().GetCriteriaList();
                    int _QuestionsCount = _CriteriaQuestions.Count();
                    int _ThisPageNo = _QuestionsCount + 2;
                    Numberleft.InnerText = _ThisPageNo.ToString();
                    NumberRight.InnerText = _ThisPageNo.ToString();
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    string _Scripts = "";
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("web\\js\\load-image.min");
                    _LoadJs.Add("web\\js\\jquery.imgareaselect.min");
                    _LoadJs.Add("web\\js\\photoupload\\oauth");
                    _LoadJs.Add("web\\js\\photoupload\\instafeed");
                    List<string> _LoadCss = new List<string>();
                    _LoadCss.Add("web\\css\\imgareaselect-default");
                    _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                    ltScripts.Text = _Scripts;
                }
                catch (Exception)
                {
                }
            }
        }
    }
}