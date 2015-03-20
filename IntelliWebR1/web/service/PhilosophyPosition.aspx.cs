using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;
using Newtonsoft.Json;

namespace IntelliWebR1.web.service
{
    public partial class PhilosophyPosition : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Clear();
            Response.ContentType = "text/json";

            if (Request.Form.AllKeys.Count() != 0)
            {
                // Post position
                string _philosophyID = Request.Form["Philosophy_id"].ToString();
                Session["PhilosophyPosition"] = _philosophyID;

                // Get has user answered and return
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                PhilosophyUserAnswer m_PhilosophyUserAnswer = new PhilosophyUserAnswer().GetPhilosophyUserAnswer(UserID, _philosophyID);


                Response.Write(JsonConvert.SerializeObject(m_PhilosophyUserAnswer != null));
            }
            else
            {
                // Get position
                if (Session["PhilosophyPosition"] != null)
                {
                    Response.Write(JsonConvert.SerializeObject(Session["PhilosophyPosition"].ToString()));
                }
                else
                {
                    Response.Write(JsonConvert.SerializeObject(""));
                }
            }
        }
    }
}