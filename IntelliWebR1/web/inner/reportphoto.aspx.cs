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
    public partial class reportphoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadPhoto();
        }

        private void LoadPhoto()
        {
            int _PhotoID = 0;
            string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
            if (Request.QueryString["pid"] != null)
            {
                _PhotoID = Convert.ToInt32(Request.QueryString["pid"]);

                string _Scripts = "<script type=\"text/javascript\">var _PhotoID=\"" + _PhotoID.ToString() + "\";</script>";
                _Scripts = _Scripts + "\n<script type=\"text/javascript\">var _SitePath=\"" + SitePath + "\"</script>";
                _Scripts = _Scripts + "\n" + "<script src=\"" + SitePath + "Scripts/js_fun.js\" type=\"text/javascript\"></script>";

                ltScripts.Text = _Scripts;

                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                bool _HasUserAlreadyReported = new PhotoReport().HasUserReportedAlready(_UserID, _PhotoID);

                if (_HasUserAlreadyReported)
                {
                    divOptions.Visible = false;
                    divAlreadyReported.Visible = true;
                }
            }
            if (Request.QueryString["path"] != null)
            {
                imgPhoto.Src = Request.QueryString["path"].ToString();
            }
        }

      
    }
}