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
    public partial class photoupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                if (HttpContext.Current.User.Identity.Name == "" || HttpContext.Current.User.Identity.Name == null)
                {
                    try
                    {
                        Response.Redirect("LogOut");
                    }
                    catch (Exception)
                    {

                    }

                }
                else
                {

                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    Photo[] _Photos = new Photo().GetUserPhotosBasedOnUserID(UserID);
                    int _Count = _Photos.Count();
                    int _ValidationCount = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["PhotoCount"]);

                    if (_Count < _ValidationCount)
                    {
                        divUploadPics.Visible = true;
                        divPhotoValdation.Visible = false;
                        string _Scripts = "";

                        List<string> _LoadCss = new List<string>();
                        _LoadCss.Add("web\\css\\photoupload");
                        _LoadCss.Add("web\\js\\photoupload\\fbphotoselector");
                        List<string> _LoadJs = new List<string>();
                        _LoadJs.Add("web\\js\\addphotos\\oauth");
                        _LoadJs.Add("web\\js\\addphotos\\instafeed");
                        _LoadJs.Add("web\\js\\addphotos\\google");
                        _LoadJs.Add("web\\js\\addphotos\\dropbox");
                        _LoadJs.Add("web\\js\\addphotos\\instagram");
                        _LoadJs.Add("web\\js\\addphotos\\fbphotos");
                        _LoadJs.Add("web\\js\\addphotos\\fbphotoselector");
                        _LoadJs.Add("web\\js\\addphotos\\onedrive");
                        _LoadJs.Add("web\\js\\addphotos\\addphotos");

                        _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());
                        _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), new List<string>().ToArray(), false);
                        string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                        ltScripts.Text = _Scripts;

                        string _SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                        btnBrowse.Attributes.Add("data-url", _SitePath + "web/inner/multiplephotoupload");
                    }
                    else
                    {
                        divPhotoValdation.Visible=true;
                        divUploadPics.Visible = false;
                    }
                }
            }
        }
    }
}