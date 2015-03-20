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
    public class VerifyEmailAddressController : ApiController
    {
        public bool Post([FromBody]EmailVerify _Obj)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                IntellidateR1.User GetUser = new IntellidateR1.User().GetUserDetails(UserID);
                bool _status = new SecurityCode().VerifyEmailStatus(UserID, _Obj.SCode, GetUser.EmailAddress);
                return _status;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }



    public class EmailVerify
    {
        public string SCode { get; set; }
    }


}
