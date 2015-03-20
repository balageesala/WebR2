using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.web.ko
{
    public partial class template_criteriaedit : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDateCombos();
        }

        private void LoadDateCombos()
        {
            try
            {
                List<string> m_Months = new List<string>();
                m_Months.Add("January");
                m_Months.Add("February");
                m_Months.Add("March");
                m_Months.Add("April");
                m_Months.Add("May");
                m_Months.Add("June");
                m_Months.Add("July");
                m_Months.Add("August");
                m_Months.Add("September");
                m_Months.Add("October");
                m_Months.Add("November");
                m_Months.Add("December");

                int _Counter = 1;
                StringBuilder m_StringBuilder = new StringBuilder();
                m_StringBuilder.Append("<option value=\"0\">Month</option>");
                foreach (string eachMonth in m_Months)
                {
                    m_StringBuilder.Append("<option value=\"" + _Counter + "\">" + eachMonth + "</option>");
                    _Counter = _Counter + 1;
                }
                ltMonths.Text = m_StringBuilder.ToString();

                m_StringBuilder = new StringBuilder();
                m_StringBuilder.Append("<option value=\"0\">Year</option>");
                for (int i = DateTime.Now.Year - 21; i > DateTime.Now.Year - 100; i--)
                {
                    m_StringBuilder.Append("<option value=\"" + i.ToString() + "\">" + i.ToString() + "</option>");
                }

                ltYears.Text = m_StringBuilder.ToString();


                m_StringBuilder = new StringBuilder();
                m_StringBuilder.Append("<option value=\"0\">Day</option>");
                for (int i = 1; i <= 31; i++)
                {
                    m_StringBuilder.Append("<option value=\"" + i.ToString() + "\">" + i.ToString() + "</option>");
                }

                ltDays.Text = m_StringBuilder.ToString();
            }
            catch (Exception)
            {

            }
        }
    }
}