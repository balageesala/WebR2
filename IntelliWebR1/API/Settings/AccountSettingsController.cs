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
    public class AccountSettingsController : ApiController
    {
        // GET api/<controller>
        public UserAccountSettings Get()
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            return new UserAccountSettings().GetUserAccountSettings(_UserID);
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]AccountSettings AccountSettings)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            if (AccountSettings.Type == "BROWSE")
            {
                new UserAccountSettings().SetBrowseInvisible(_UserID, AccountSettings.ValueToUpdate);
            }

            if (AccountSettings.Type == "SAVE")
            {
                new UserAccountSettings().SetSaveInvisible(_UserID, AccountSettings.ValueToUpdate);
            }
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }

    public class AccountSettings
    {
        public string Type { get; set; }
        public bool ValueToUpdate { get; set; }
    }
}
