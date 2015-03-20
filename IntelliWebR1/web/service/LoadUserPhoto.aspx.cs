using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.service
{
    public partial class LoadUserPhoto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                string _ControlToSelect = Request.QueryString["c"].ToString();
                int _OtherUserID = (Request.QueryString["ouid"] == null) ? 0 : Convert.ToInt32(Request.QueryString["ouid"]);

                switch (_ControlToSelect)
                {
                    case "USERPIC":
                        {
                            convuserpic.Visible = true;
                            convuserpic.UserID = _OtherUserID;
                            break;
                        }
                }

            }
            catch (Exception)
            {

            }
        }
    }
}