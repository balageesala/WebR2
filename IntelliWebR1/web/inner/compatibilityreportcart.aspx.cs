using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.inner
{
    public partial class compatibilityreportcart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                try
                {
                    string _Scripts = "";
                    List<string> _Loadcss = new List<string>();
                    _Loadcss.Add("web\\css\\popups");
                    _Scripts = _Scripts + "\n" + Helper.LoadCSS(_Loadcss.ToArray());

                    List<string> _LoadMessages = new List<string>();
                    List<string> _LoadJs = new List<string>();
                    _LoadJs.Add("Scripts\\js_fun");
                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);

                    ltScripts.Text = _Scripts;
                    string SitePath = System.Configuration.ConfigurationManager.AppSettings["SitePath"].ToString();
                    if (Request.QueryString["RematchID"] != null)
                    {
                        /// <summary>
                        ///  1 = Rematch (this is contain expire date) 2.5$
                        ///  2 = Compatability report 1$ (only one report for 1$)
                        ///  3 = facebook and linkedin contacts(mutual friends) 1$
                        ///  4 = read/deleted 0.5 $ (this is for 2 users conversations read/delete status)
                        /// </summary>
                        int _RematchID = Convert.ToInt32(Request.QueryString["RematchID"]);
                        int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);

                        User _ThisUser = new User().GetUserDetails(UserID);
                        if (_ThisUser.IsUserSubscribed)
                        {
                            divSubscriber.Visible = true;
                            divPayUser.Visible = false;
                        }
                        else
                        {
                            divPayUser.Visible = true;
                            divSubscriber.Visible = false;
                        }

                        User _GetUser = new User().GetUserDetails(_RematchID);
                        //create sesssion for maintain rematchid Session["OtherUserID"] = null;  Session["CartType"] = null;

                        Session["OtherUserID"] = _RematchID.ToString();
                        Session["CartType"] = "2";
                        if (_GetUser.ProfilePhoto != null)
                        {
                            imgReMatchImage.Src = new Utils().GetPhotoPCTPath(_GetUser.ProfilePhoto.PhotoID, Page.Request);
                        }
                        else
                        {
                            if (_GetUser.Gender == 1)
                            {
                                imgReMatchImage.Src = SitePath + "web/images/M.png";
                            }
                            else
                            {
                                imgReMatchImage.Src = SitePath + "web/images/F.png";
                            }
                        }
                        divRematchName.InnerHtml = _GetUser.LoginName;
                    }
                }
                catch (Exception)
                {
                }
            }
        }
    }
}