using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntelliWebR1.web.inner
{
    public partial class makeascoverphoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string _Scripts = "";
               
                List<string> _LoadMessages = new List<string>();

                List<string> _LoadCss = new List<string>();

               
                _LoadCss.Add("web\\css\\imgareaselect-default");

                _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());

                List<string> _LoadJs = new List<string>();
                _LoadJs.Add("web\\js\\load-image.min");
                _LoadJs.Add("web\\js\\jquery.imgareaselect.min");
                _LoadJs.Add("Scripts\\js_fun");
                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);

                string _PhotoPath = string.Empty;
                if (Request.QueryString["pid"] != null)
                {
                    int _PhotoID = Convert.ToInt32(Request.QueryString["pid"]);
                    _PhotoPath = new Utils().GetPhotoFullViewPath(_PhotoID, Page.Request);
                }

                _Scripts = _Scripts + "\n" + "<script type=\"text/javascript\">var _PhotoPath =\"" + _PhotoPath + "\"</script>";
               
                
                ltScripts.Text = _Scripts;
            }
        }

       
    }
}