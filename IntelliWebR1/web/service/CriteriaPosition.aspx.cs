using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using IntellidateR1;

namespace IntelliWebR1.web.service
{
    public partial class CriteriaPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "text/json";

            if (Request.Form.AllKeys.Count() != 0)
            {
                // Post position
                string _criteriaID = Request.Form["Criteria_id"].ToString();
                Session["CriteriaPosition"] = _criteriaID;

                // Get has user answered and return
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                CriteriaUserAnswer m_CriteriaUserAnswer = new CriteriaUserAnswer().GetCriteriaUserAnswer(UserID, _criteriaID);


                Response.Write(JsonConvert.SerializeObject(m_CriteriaUserAnswer!=null));
            }
            else
            {
                // Get position
                if (Session["CriteriaPosition"] != null)
                {
                    Response.Write(JsonConvert.SerializeObject(Session["CriteriaPosition"].ToString()));
                }
                else
                {
                    Response.Write(JsonConvert.SerializeObject(""));
                }
            }
        }
    }
}