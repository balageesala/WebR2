using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class loadphoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    if (Request.QueryString["pid"] != null)
                    {
                        int PhotoID = Convert.ToInt32(Request.QueryString["pid"]);
                        Photo _PhotoDetails = new Photo().GetPhotoDetails(PhotoID);
                        string _PhotoPath = new Utils().GetPhotoFullViewPath(PhotoID, Page.Request);
                        imgDiscussPhoto.Src = _PhotoPath;
                        hPhotoTitle.InnerText = _PhotoDetails.Caption;
                    }
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}