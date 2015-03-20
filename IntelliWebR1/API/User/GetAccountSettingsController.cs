using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IntellidateR1;
using System.Web;

namespace IntelliWebR1.API
{
    public class GetAccountSettingsController : ApiController
    {
        public UserAccountSettings Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new UserAccountSettings().GetUserAccountSettings(_UserID);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
