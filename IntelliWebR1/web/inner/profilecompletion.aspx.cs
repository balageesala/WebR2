using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Web.UI.HtmlControls;
using IntellidateR1;


namespace IntelliWebR1.web.inner
{
    public partial class profilecompletion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
            if (!Page.IsPostBack)
            {
                LoadProfileCompletionRules();
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                string _Profilep=new ProfileCompletion().GetTotalProfileCompletion(UserID).ToString();
                lblProfileCompletionText.InnerHtml = _Profilep + "% Complete. ";
              //  imgPercentageMeter.Src = _SitePath + "web/service/PercentageMeter?p=" + _Profilep;
            }
        }

        protected void ProfileCompletion_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                string _SitePath = ConfigurationManager.AppSettings["SitePath"].ToString();
                DataRowView _Row = (DataRowView)e.Item.DataItem;
                // ((HtmlGenericControl)e.Item.FindControl("divAbout")).InnerText = _Row[2].ToString();

               
               ((HtmlGenericControl)e.Item.FindControl("divPoints")).InnerHtml = "<a class='anchortag' href=" + _SitePath + _Row[4].ToString() + "><div style='float:left;'> " + _Row[1].ToString() + "&nbsp;</div><div style='font-weight:bold;float:left;'>+ (" + _Row[2].ToString() + "/" + _Row[0].ToString() + ") points</div></a>";
                
            }
            catch (Exception)
            {

            }
        }

        private void LoadProfileCompletionRules()
        {
            try
            {
                
                DataTable _DataTable = new DataTable();
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                _DataTable = new ProfileCompletion().UserGettingPoints(UserID);

                DataTable _ReovedItems = new DataTable();
                DataColumn _NewColumn;
                foreach (DataColumn _NewDC in _DataTable.Columns)
                {
                    _NewColumn = new DataColumn(_NewDC.ColumnName);
                    _ReovedItems.Columns.Add(_NewColumn);
                }

                DataRow _DR;
                foreach (DataRow _NewRow in _DataTable.Rows)
                {
                    if(_NewRow[0].ToString().Trim()==_NewRow[2].ToString().Trim())
                    {

                    }
                    else
                    {
                        _DR = _ReovedItems.NewRow();
                        _DR[0] = _NewRow[0];
                        _DR[1] = _NewRow[1];
                        _DR[2] = _NewRow[2];
                        _DR[3] = _NewRow[3];
                        _DR[4] = _NewRow[4];
                      //  _DR[5] = _NewRow[5];
                      //  _DR[6] = _NewRow[6];
                        _ReovedItems.Rows.Add(_DR);
                    }
                }



                rptProfileCompletion.DataSource = _ReovedItems;
                rptProfileCompletion.DataBind();

            }
            catch (Exception)
            {

            }
        }

        private bool CheckPointStatus(string Title)
        {
            try
            {
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}