using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using IntellidateR1;
using System.Web.Security;
using System.IO;
using Newtonsoft.Json;
using System.Configuration;

namespace IntelliWebR1.post
{
    public partial class register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AuthenticationResponse m_AuthenticationResponse = new AuthenticationResponse();
            Response.ContentType = "text/json";

            if (Request.Form != null)
            {
                try
                {
                    int m_GenderID = Convert.ToInt32(Request.Form["gr"]);
                    int m_GenderLookingForID = Convert.ToInt32(Request.Form["grlooking"]);
                    string m_LoginName = Request.Form["ln"].ToString();
                    string m_EmailAddress = Request.Form["em"].ToString();
                    string m_Password = Request.Form["pwd"].ToString();


                    int Dob_Month = Convert.ToInt32(Request.Form["dm"]);
                    int Dob_Year = Convert.ToInt32(Request.Form["dy"]);
                    int Dob_Day = Convert.ToInt32(Request.Form["dd"]);

                    DateTime m_DateOfBirth = new DateTime();

                    m_DateOfBirth = new DateTime(Dob_Year, Dob_Month, Dob_Day);
                    int _Age = new DateTime(DateTime.Now.Subtract(m_DateOfBirth).Ticks).Year - 1;
                    if (_Age >= 21 && _Age <= 99)
                    {
                        User m_UserDetails = new User().RegisterUser(m_LoginName, m_EmailAddress, m_Password, m_GenderID,m_GenderLookingForID, m_DateOfBirth);
                        if (m_UserDetails != null)
                        {
                            // Enqueue email
                            EnqueueEmail(m_UserDetails.UserID, m_UserDetails.EmailAddress);

                            FormsAuthentication.SetAuthCookie(m_UserDetails.UserID.ToString(), true);
                            FormsAuthenticationTicket intellidateTicket = new FormsAuthenticationTicket(1, m_UserDetails.UserID.ToString(), DateTime.Now, DateTime.Now.AddDays(30), true, "");
                            HttpCookie intellidateCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(intellidateTicket));
                            Response.Cookies.Add(intellidateCookie);
                            m_AuthenticationResponse.Result = true;
                            if (m_UserDetails.Status == "A")
                            {
                                m_AuthenticationResponse.RedirectPath = "web/Home";
                            }
                            else
                            {
                                m_AuthenticationResponse.RedirectPath = "web/Criteria";
                            }
                        }
                        else
                        {
                            m_AuthenticationResponse.Result = false;
                            m_AuthenticationResponse.RedirectPath = "NICK";
                        }
                    }
                    else
                    {
                        m_AuthenticationResponse.Result = false;
                        m_AuthenticationResponse.RedirectPath = "AGE";
                    }
                }
                catch (Exception ex)
                {
                    LogError(ex);
                    m_AuthenticationResponse.Result = false;
                    m_AuthenticationResponse.RedirectPath = "DOB";

                }
                Response.Clear();
                Response.Write(JsonConvert.SerializeObject(m_AuthenticationResponse));

            }
        }

        private void EnqueueEmail(int UserID, string EmailAddress)
        {
            try
            {
                string _Subject = ConfigurationManager.AppSettings["RegisterEmailSubject"].ToString();
                string _BodyPath = File.ReadAllText(ConfigurationManager.AppSettings["RegisterEmailTemplatePath"].ToString());
                int _Priority = Convert.ToInt32(ConfigurationManager.AppSettings["RegisterEmailPriority"].ToString());

                string _Body = string.Empty;
                _Body = new Utils().ConvertEmailBody(_BodyPath);
                _Body = _Body.Replace("[EMAIL_ID]", EmailAddress);
                _Body = _Body.Replace("[PRIORITY]", _Priority.ToString());
                if (_Body != "" && EmailAddress != "")
                {
                    new EmailQueue().EnqueEmail(UserID, EmailAddress, _Subject, _Body, _Priority);
                }
            }
            catch (Exception ex)
            {
                IntellidateR1.Error.LogError(ex, "register EnqueueEmail");
            }
        }

        private void LogError(Exception ex)
        {
            try
            {
                string _FileName = "C:\\Logs\\Error_" + DateTime.Now.ToString("ddMMyyyyhhmmss") + ".txt";
                string _JsonString = JsonConvert.SerializeObject(ex);

                if (File.Exists(_FileName))
                {
                    File.AppendAllText(_FileName, "\n\n\r\r-------------------------------\n\n\r\r");
                    File.AppendAllText(_FileName, _JsonString);
                }
                else
                { File.WriteAllText(_FileName, _JsonString); }
            }
            catch (Exception)
            {

            }
        }
    }
}