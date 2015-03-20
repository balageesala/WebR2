using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class UpdateAccountSettingsController : ApiController
    {
        public bool Post([FromBody]AccountProps AccountObj)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new UserAccountSettings().UpdateAccountSettings(_UserID, AccountObj.InstantMessanger, AccountObj.OneTimeLimit, AccountObj.AccoutStatus, AccountObj.BrowseInvisibleOption, AccountObj.SaveInvisibleOption);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class AccountProps
    {
        public bool InstantMessanger { get; set; }
        public int OneTimeLimit { get; set; }
        public string AccoutStatus { get; set; }
        public bool BrowseInvisibleOption { get; set; }
        public bool SaveInvisibleOption { get; set; }
    }




}
