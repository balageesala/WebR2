using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IntellidateR1;

namespace IntellidateR1Web.web
{
    public partial class EmailVerification : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                try
                {
                    ((Intellidate)this.Master).MenuDisplay(false);
                    ((Intellidate)this.Master).ContainerBoxDisplay(true);
                    ((Intellidate)this.Master).HomeIConDisplay(false);

                     int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                     bool IsEmailVerified = new UserAccountSettings().GetUserAccountSettings(UserID).IsUserEmailVerified;

                        if (!IsEmailVerified)
                        {
                            User GetUser = new User().GetUserDetails(UserID);

                            string Code = new SecurityCode().GetSecurityCode(UserID, GetUser.EmailAddress);

                            //send email to code
                            int _priority = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["SecurityCodeEmailPriority"]);

                            new EmailQueue().EnqueEmail(UserID, GetUser.EmailAddress, "Verification Code : ", "Your email verification code is " + Code, _priority);

                        }
                        else
                        {

                        }

                }
                catch (Exception)
                {
                    
                   
                }
            }
        }

  }
}