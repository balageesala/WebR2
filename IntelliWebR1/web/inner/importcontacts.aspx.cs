using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using IntellidateR1;
using System.Text;
using System.Web.UI.HtmlControls;

namespace IntelliWebR1.web.inner
{
    public partial class importcontacts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string _Scripts = "";
            List<string> _Loadcss = new List<string>();
            _Loadcss.Add("web\\css\\intellidate");
            _Scripts = _Scripts + "\n" + Helper.LoadCSS(_Loadcss.ToArray());

            List<string> _LoadMessages = new List<string>();
            List<string> _LoadJs = new List<string>();
            _LoadJs.Add("Scripts\\js_fun");
            _Scripts = _Scripts + "\n" + Helper.LoadScripts(_LoadJs.ToArray(), _LoadMessages.ToArray(), true);

            ltScripts.Text = _Scripts;
            BindExistingContacts();
        }

        protected void btnAddContact_ServerClick(object sender, EventArgs e)
        {
            try
            {
                int _OptionType = Convert.ToInt32(ddlOptions.Value);
                if (_OptionType != 0)
                {
                    if (browseExcel.PostedFile.FileName != "")
                    {
                        int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                        string fileName = browseExcel.ResolveClientUrl(browseExcel.PostedFile.FileName);
                        string _SitePath = System.Configuration.ConfigurationManager.AppSettings["SitePath"].ToString();
                        string _dateString = DateTime.Now.ToString("ddMMyyhhmmss");
                        string _FilePath = Server.MapPath("/web/csvfiles/" + _dateString + fileName);
                        browseExcel.PostedFile.SaveAs(_FilePath);
                        DataTable dtExcel = new DataTable();
                        dtExcel = GetDataTabletFromCSVFile(_FilePath);
                        int _insertCount = 0;
                        foreach (DataRow _DR in dtExcel.Rows)
                        {
                            string _FirstName = _DR["First Name"].ToString();
                            string _LastName = _DR["Last Name"].ToString();
                            string _EmailAddress = _DR["E-mail Address"].ToString().Trim();
                            string _birthday = _DR["Birthday"].ToString();
                            DateTime? _Dob = null;
                            if (_birthday != "")
                            {
                                _Dob = Convert.ToDateTime(_birthday);
                            }

                            string _Mob1 = _DR["Primary Phone"].ToString();
                            string _Mob2 = _DR["Mobile Phone"].ToString();
                            string _City = _DR["Location"].ToString();
                            _insertCount = _insertCount + 1;
                            if (_EmailAddress != "")
                            {
                                new UserEmailContacts().AddUserContacts(_UserID, _FirstName, _LastName, _EmailAddress, _Mob1, _Mob2, _OptionType, _City, "", "", _Dob);
                            }
                        }
                        if (_insertCount == dtExcel.Rows.Count)
                        {
                            lblMessageResponse.InnerHtml = "Your contacts successfully added.";
                            BindExistingContacts();
                        }
                        else
                        {

                            lblMessageResponse.InnerHtml = "Opp's Error.";
                        }

                    }
                    else
                    {
                        lblMessageResponse.InnerHtml = "Please select .csv file. ";
                    }

                }
                else
                {
                    lblMessageResponse.InnerHtml = "Please select an option from dropdown list. ";
                }
            }
            catch (Exception)
            {

                lblMessageResponse.InnerHtml = "Opp's Error.";
            }
        }


        public DataTable GetDataTabletFromCSVFile(string csv_file_path)
        {
            DataTable csvData = new DataTable();
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csv_file_path))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;
                    //read column names
                    string[] colFields = csvReader.ReadFields();
                    foreach (string column in colFields)
                    {
                        DataColumn datecolumn = new DataColumn(column);
                        datecolumn.AllowDBNull = true;
                        csvData.Columns.Add(datecolumn);
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();

                        // Making empty value as null
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            if (fieldData[i] == "")
                            {
                                fieldData[i] = null;
                            }
                        }


                        if (colFields.Count() == fieldData.Count())
                        {
                            csvData.Rows.Add(fieldData);
                        }
                        else if (colFields.Count() < fieldData.Count())
                        {
                            string[] _data = fieldData.Take(fieldData.Length - 1).ToArray();

                            if (colFields.Count() == _data.Count())
                            {
                                csvData.Rows.Add(_data);
                            }
                        } 
                    }
                }
                return csvData;
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }


        public void BindExistingContacts()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                UserEmailContacts[] _AllContacts = new UserEmailContacts().GetUserEmailContacts(_UserID);
                if (_AllContacts.Count() > 0)
                {

                    divExistingContacts.Visible = true;
                    rptContacts.ItemDataBound += rptContacts_ItemDataBound;
                    rptContacts.DataSource = _AllContacts;
                    rptContacts.DataBind();

                }
               

            }
            catch (Exception)
            {

            }
        }


        void rptContacts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            try
            {
                 UserEmailContacts m_Contact = (UserEmailContacts)e.Item.DataItem;
                 ((HtmlGenericControl)e.Item.FindControl("DivContactEmail")).InnerText = m_Contact.EmailAddress;
                 ((HtmlGenericControl)e.Item.FindControl("DivContactID")).Attributes.Add("data-id", m_Contact.ContactID.ToString());
            }
            catch (Exception)
            {

            }
        }
    }
}