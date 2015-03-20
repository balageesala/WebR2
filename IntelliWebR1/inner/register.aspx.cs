using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace IntelliWebR1.inner
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDateCombos();

                string _Scripts = "";

                List<string> _LoadMessages = new List<string>();
                _LoadMessages.Add("LOGIN");
                _LoadMessages.Add("REG");

                List<string> _LoadScripts = new List<string>();
             //   _LoadScripts.Add("scripts\\js_fun"); 
                _LoadScripts.Add("scripts\\register");

                _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadScripts.ToArray(), _LoadMessages.ToArray(),false);


                ltScripts.Text = _Scripts;

                PopulateLinks();
            }
        }

        private void LoadDateCombos()
        {
            try
            {
                List<string> _Months = new List<string>();
                _Months.Add("Month");
                _Months.Add("January");
                _Months.Add("February");
                _Months.Add("March");
                _Months.Add("April");
                _Months.Add("May");
                _Months.Add("June");
                _Months.Add("July");
                _Months.Add("August");
                _Months.Add("September");
                _Months.Add("October");
                _Months.Add("November");
                _Months.Add("December");

                int _Position = 0;
                foreach (string EachMonth in _Months)
                {
                    cboMonth.Items.Add(new ListItem(EachMonth, _Position.ToString("D2")));
                    _Position++;
                }

                cboDate.Items.Add(new ListItem("Day", "0"));
                for (int i = 1; i <= 31; i++)
                {
                    cboDate.Items.Add(new ListItem(i.ToString(), i.ToString("D2")));
                }

                cboYear.Items.Add(new ListItem("Year", "0"));
                for (int i = DateTime.Now.AddYears(-21).Year; i >= DateTime.Now.AddYears(-100).Year; i--)
                {
                    cboYear.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            catch (Exception)
            {

            }
        }

        private void PopulateLinks()
        {
            string SitePath = "";
            try
            {
                SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                lnkTerms.HRef = SitePath + "Terms";
                lnkLogin.Attributes.Add("data-url", SitePath + "inner/login.aspx");
                lnkforgotpwd.Attributes.Add("data-url", SitePath + "inner/forgotpassword.aspx");
                lnkFbRegister.Attributes.Add("data-url", SitePath + "inner/fbregister.aspx");
            }
            catch (Exception)
            {

            }
        }
    }
}