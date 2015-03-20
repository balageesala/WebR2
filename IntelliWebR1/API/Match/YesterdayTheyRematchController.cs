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
    public class YesterdayTheyRematchController : ApiController
    {
        public int Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                ProfileRematch _TheyRematch = new ProfileRematch().GetYesterdayTheyReMatch(_UserID);
                return _TheyRematch.UserID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
