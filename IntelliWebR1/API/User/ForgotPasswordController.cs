using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Configuration;
using System.IO;

namespace IntelliWebR1.API
{
    public class ForgotPasswordController : ApiController
    {
        public bool Post([FromBody]ForgotPassword _ForgotPassword)
        {
            IntellidateR1.User _UserDetails =  new IntellidateR1.User().GetUserDetails(_ForgotPassword.EmailAddress,true);

            if (_UserDetails == null)
            {
                return false;
            }
            else
            {
                if (_UserDetails.Status == "A")
                {
                    //send only 3 times for a day

                    int _PasswordSendCount = new PasswordEmailAttempts().GetPasswordSentCount(_UserDetails.EmailAddress);

                    if (_PasswordSendCount <= 3)
                    {
                        //send password to email address.
                        string _Subject = ConfigurationManager.AppSettings["ForgotPwdEmailSubject"].ToString();
                        string _BodyPath = File.ReadAllText(ConfigurationManager.AppSettings["ForgotPwdEmailTemplatePath"].ToString());
                        int _Priority = Convert.ToInt32(ConfigurationManager.AppSettings["ForgotPwdEmailPriority"].ToString());

                        string _Body = string.Empty;
                        string EmailAddress = _UserDetails.EmailAddress;
                        string _password = _UserDetails.Password;
                        int _UserID = _UserDetails.UserID;
                        _Body = new Utils().ConvertEmailBody(_BodyPath);
                        _Body = _Body.Replace("[EMAIL_ID]", EmailAddress);
                        _Body = _Body.Replace("[PRIORITY]", _Priority.ToString());
                        _Body = _Body.Replace("[USER_PASSWORD]", _password);


                        if (_Body != "" && EmailAddress != "")
                        {
                            new EmailQueue().EnqueEmail(_UserID, EmailAddress, _Subject, _Body, _Priority);
                            new PasswordEmailAttempts().AddSendPasswordAttempt(EmailAddress);
                        }
                        return true;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }

        }
    }


    public class ForgotPassword
    {
        public string EmailAddress { get; set; }
    }

}
