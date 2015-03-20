using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web
{
    public partial class ProfilePercentage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    string SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                    int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                    User UserDetails = new User().GetUserDetails(UserID);
                    hprofile.InnerText = "Your Profile is " + new ProfileCompletion().GetTotalProfileCompletion(UserID).ToString() + "% complete";
                    StringBuilder _Sb = new StringBuilder();
                    DataTable _DT = new ProfileCompletion().UserGettingPoints(UserID);
                    foreach (DataRow _Dr in _DT.Rows)
                    {
                        _Sb.Append("<h3>" + _Dr[1] + "</h3>");
                        decimal Remaningp = Convert.ToDecimal(_Dr[0]) - Convert.ToDecimal(_Dr[2]);
                        if (Remaningp != 0)
                        {
                            _Sb.Append("<div class='toggle_text'><p>This section you got " + _Dr[2] + " % and remaning " + Remaningp.ToString() + "% </p><input type='button' class='btnupdate' value='Update' data-link=" + SitePath + _Dr[4].ToString() + "/></div>");
                        }
                        else
                        {
                            _Sb.Append("<div class='toggle_text'><p>This section you got full percentage</p></div>");  
                        }
                    }
                    divAccordion.InnerHtml = _Sb.ToString();
                }
            }
            catch (Exception)
            {  
                throw;
            }
        }
    }
}