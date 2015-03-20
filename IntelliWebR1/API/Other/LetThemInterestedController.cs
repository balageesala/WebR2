using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Other
{
    public class LetThemInterestedController : ApiController
    {
        public bool Post([FromBody]ThemInterestedProfile _InterestedObj)
        {
            try
            {
                int UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                return new LetThemInterested().AddLetThemInterested(UserID, _InterestedObj.InterestedUserID);
            }
            catch (Exception)
            {

                return false;
            }
        }

    }

    public class ThemInterestedProfile
    {
        public int InterestedUserID { get; set; }
    }

}
