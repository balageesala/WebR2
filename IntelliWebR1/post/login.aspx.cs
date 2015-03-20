using IntellidateR1;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelliWebR1.post
{
    public partial class login : System.Web.UI.Page
    {
        public string SitePath = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form != null)
            {
                string _Response = LoginUser();
                Response.ContentType = "text/json";
                Response.Write(_Response);
            }
        }

        private string LoginUser()
        {
            AuthenticationResponse _AuthenticationResponse = new AuthenticationResponse { Result = false };
            try
            {
                string m_LoginName = string.Empty;
                string m_Password = string.Empty;
                bool m_IsRemember = false;
                if (Request.Form["EmailAddress"] != null && Request.Form["IsFB"] != null)
                {
                    string _UserEmail = Request.Form["EmailAddress"].ToString();
                    User _ThisUser = new User().GetUserDetails(_UserEmail, true);
                    m_LoginName = _ThisUser.LoginName;
                    m_Password = _ThisUser.Password;
                    m_IsRemember = false;
                }
                else
                {
                    m_LoginName = Request.Form["LoginName"].ToString();
                    m_Password = Request.Form["Password"].ToString();
                    m_IsRemember = Convert.ToBoolean(Request.Form["IsRemember"].ToString());
                }

                 bool IsEmailLogin = IsValidEmail(m_LoginName);
                 User m_UserDetails;

                if (IsEmailLogin)
                {
                    m_UserDetails = new User().AuthenticateUserWithEmail(m_LoginName, m_Password);
                }
                else
                {
                    m_UserDetails = new User().AuthenticateUser(m_LoginName, m_Password);
                }
                if (m_UserDetails != null)
                {

                    string ACCOUNT_STATUS = new UserAccountSettings().GetUserAccountSettings(m_UserDetails.UserID).AccoutStatus;

                    if (ACCOUNT_STATUS.ToUpper() == "A")
                    {

                        if (!m_IsRemember)
                        {
                            FormsAuthentication.RedirectFromLoginPage(m_UserDetails.UserID.ToString(), false);

                            if (m_UserDetails.Status == "A")
                            {
                                // Check if any unanswered Criteria questions
                                Criteria[] _UnAnsweredCriteriaQuestions = new Criteria().GetUnAnsweredQuestions(m_UserDetails.UserID);
                                _AuthenticationResponse.Result = true;
                                if (_UnAnsweredCriteriaQuestions.Count() == 0)
                                {
                                    _AuthenticationResponse.RedirectPath = "Web/Home";
                                }
                                else
                                {
                                    _AuthenticationResponse.RedirectPath = "Web/Criteria";
                                }

                            }
                            if (m_UserDetails.Status == "P")
                            {
                                _AuthenticationResponse.RedirectPath = "Web/Criteria";
                            }
                            if (m_UserDetails.Status == "I")
                            {
                                _AuthenticationResponse.RedirectPath = "Delete";
                            }
                        }

                        else
                        {

                            FormsAuthentication.SetAuthCookie(m_UserDetails.UserID.ToString(), true);
                            FormsAuthenticationTicket intellidateTicket = new FormsAuthenticationTicket(1, m_UserDetails.UserID.ToString(), DateTime.Now, DateTime.Now.AddDays(30), true, "");
                            HttpCookie intellidateCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(intellidateTicket));
                            Response.Cookies.Add(intellidateCookie);

                            _AuthenticationResponse.Result = true;
                            if (m_UserDetails.Status == "A")
                            {
                                // Check if any unanswered Criteria questions
                                Criteria[] _UnAnsweredCriteriaQuestions = new Criteria().GetUnAnsweredQuestions(m_UserDetails.UserID);

                                if (_UnAnsweredCriteriaQuestions.Count() == 0)
                                {
                                    _AuthenticationResponse.RedirectPath = "Web/Home";
                                }
                                else
                                {
                                    _AuthenticationResponse.RedirectPath = "Web/Criteria";
                                }

                            }
                            if (m_UserDetails.Status == "P")
                            {
                                _AuthenticationResponse.RedirectPath = "Web/Criteria";
                            }
                            if (m_UserDetails.Status == "I")
                            {
                                _AuthenticationResponse.RedirectPath = "Delete";
                            }
                        }
                    }
                    else if (ACCOUNT_STATUS.ToUpper() == "I")
                    {
                        FormsAuthentication.SetAuthCookie(m_UserDetails.UserID.ToString(), true);
                        FormsAuthenticationTicket intellidateTicket = new FormsAuthenticationTicket(1, m_UserDetails.UserID.ToString(), DateTime.Now, DateTime.Now.AddDays(30), true, "");
                        HttpCookie intellidateCookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(intellidateTicket));
                        Response.Cookies.Add(intellidateCookie);

                        _AuthenticationResponse.Result = true;
                        _AuthenticationResponse.RedirectPath = "Web/ActivateAccount";
                    }
                    else if (ACCOUNT_STATUS.ToUpper() == "D")
                    {
                        _AuthenticationResponse.Result = false;
                        _AuthenticationResponse.RedirectPath =null;
                    }

                }
            }
            catch (Exception ex)
            {
                IntellidateR1.Error.LogError(ex, "Login LoginUser");
                _AuthenticationResponse.Result = false;
            }
            return JsonConvert.SerializeObject(_AuthenticationResponse);
        }


        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}