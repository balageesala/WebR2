using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Match
{
    public class GetPastMatchsController : ApiController
    {
        public UserMatchs[] Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                UserMatchs[] _AllPastMatchs = new UserMatchs().GetPastMatchs(_UserID);
                return _AllPastMatchs;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
