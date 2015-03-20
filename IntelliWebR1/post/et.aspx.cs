using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1.post
{
    public partial class et : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                // Log the email view
                if (Request.QueryString["i"] != null && Request.QueryString["p"] != null)
                {
                    string _EmailCacheID = Request.QueryString["i"].ToString();
                    int _priorty = Convert.ToInt32(Request.QueryString["p"]);
                    new EmailQueue().SetEmailRead(_EmailCacheID, _priorty);
                }

                // Logo path
                Response.ContentType = "image/png";
                Response.Clear();
                Response.WriteFile(ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + "logo.png");
            }
            catch (Exception ex)
            {

            }
        }
    }
}