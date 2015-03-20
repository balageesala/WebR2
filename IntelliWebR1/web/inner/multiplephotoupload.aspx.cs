using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntelliWebR1.web.inner
{
    public partial class multiplephotoupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string _Scripts = "";

                List<string> _LoadMessages = new List<string>();

                List<string> _LoadScripts = new List<string>();
                _LoadScripts.Add("scripts\\js_fun");
                _LoadScripts.Add("web\\js\\load-image.min");

                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(), true);

                List<string> _LoadCss = new List<string>();
                _LoadCss.Add("web\\css\\popups");
                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());

                ltScripts.Text = _Scripts;
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                int _totalPhotosUploaded = new Photo().GetUserPhotosBasedOnUserID(UserID).Count();
                int _totalCount = Convert.ToInt32(ConfigurationManager.AppSettings["PhotoCount"]);
                int _AvilableCount = _totalCount - _totalPhotosUploaded;
                divAvilable.InnerText = _AvilableCount.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}