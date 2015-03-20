using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.IO;
using IntellidateR1;
using System.Configuration;

namespace IntelliWebR1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();

                    int _IsLoggedInRedirect = CheckIsLoggedIn();

                    string _RedirectPage = "";
                    if (_IsLoggedInRedirect > 0)
                    {
                        switch (_IsLoggedInRedirect)
                        {
                            case 1:
                                _RedirectPage = SitePath + "web/Criteria";
                                break;

                            case 2:
                                _RedirectPage = SitePath + "web/PhotoUpload";
                                break;

                            case 3:
                                _RedirectPage = SitePath + "web/Home";
                                break;
                            default:
                                _RedirectPage = SitePath + "web/LogOut";
                                break;
                        }

                        try
                        {
                            Response.Redirect(_RedirectPage);
                        }
                        catch (Exception)
                        {
                           //update questions to live
                           
                        }
                        
                    }

                    string _Scripts = "";

                    // -- Load CSS
                    List<string> _LoadCss = new List<string>();
                    _LoadCss.Add("css\\default");
                    _LoadCss.Add("css\\intelliwindow");

                    _Scripts = _Scripts + "\n" + Helper.LoadCSS(_LoadCss.ToArray());


                    // -- Load Javascript
                    List<string> _LoadMessages = new List<string>();
                    List<string> _LoadScripts = new List<string>();
                    _LoadScripts.Add("scripts\\js_fun");
                    _LoadScripts.Add("scripts\\default");
                    _LoadScripts.Add("scripts\\intelliwindow");

                    _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(), true);

                    ltScripts.Text = _Scripts;

                    FillGrid();
                
            }
            catch (Exception)
            {

            }
        }

        private int CheckIsLoggedIn()
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name != null && HttpContext.Current.User.Identity.Name != "")
                {
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    User UserDetails = new User().GetUserDetails(UserID);
                    // Check if the user has answered all the criteria questions
                  //  bool HasUserAnsweredCriteria = new CriteriaUserAnswerWeek().HasUserAnsweredCriteria(UserID);


                    if (UserDetails.Status == "P")
                    {
                        return 1;
                    }
                    // Has User uploaded photo
                    Photo _DefaultPhoto = new Photo().ThisUserDefaultPhoto(UserID);
                    if (_DefaultPhoto == null)
                    {
                        return 2;
                    }

                    return 3;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private void FillGrid()
        {
            try
            {
                string _GridPhotosPath = ConfigurationManager.AppSettings["PhotosRootPath"].ToString() + "\\grid\\";
                string[] _Files = Directory.GetFiles(_GridPhotosPath);


                List<string> _AllPhotos = new List<string>();
                if (new Utils().IsAcceptWebP(Page.Request))
                {
                    _AllPhotos = _Files.Where(x => x.EndsWith(".webp")).ToList();
                }
                else
                {
                    _AllPhotos = _Files.Where(x => x.EndsWith(".jpg")).ToList();
                }
                
                List<string> _GridPhotos = new List<string>();

                for (int i = 0; i < 15; i++)
                {
                    string _Photo = GetRandomFromArray(_AllPhotos.ToArray());
                    _AllPhotos.Remove(_Photo);
                    _GridPhotos.Add(_Photo);
                }

                rptPhotosGrid.DataSource = _GridPhotos;
                rptPhotosGrid.DataBind();

            }
            catch (Exception)
            {

            }
        }

        private string GetRandomFromArray(string[] InArray)
        {
            try
            {
                Random _r = new Random();
                int _pos = _r.Next(InArray.Count() - 1);
                return InArray[_pos];
            }
            catch (Exception)
            {
                return InArray[0];
            }
        }

        protected void rptPhotosGrid_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                string _PhotoPath = (string)e.Item.DataItem;

                _PhotoPath = _PhotoPath.Split('\\')[_PhotoPath.Split('\\').Length - 1];
                ((HtmlImage)e.Item.FindControl("imgGridPhoto")).Src = ConfigurationManager.AppSettings["PhotosRootUrl"].ToString() + "grid/" + _PhotoPath;

            }
            catch (Exception)
            {

            }
        }
        
    }
}