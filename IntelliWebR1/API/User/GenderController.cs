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
    public class GenderController : ApiController
    {
        // GET api/<controller>
        public int Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                IntellidateR1.User UserDetails = new IntellidateR1.User().GetUserDetails(_UserID);

                return UserDetails.Gender;
            }
            catch (Exception)
            {
                return 1;
            }
        }

        // POST api/<controller>
        public bool Post([FromBody]GenderClass Gender)
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool _Return = new IntellidateR1.User().ChangeUserGender(_UserID, Gender.GenderSelected);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class GenderClass
    {
        public int GenderSelected { get; set; }
    }
}
