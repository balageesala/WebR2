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
    public class GetThisDayMatchController : ApiController
    {
        // POST api/<controller>
        public ThisdayMatchUser Post([FromBody]ThisDayMyMatch _ThisObject)
        {
            try
            {
                DateTime _date = new DateTime(_ThisObject.ThisYear, (_ThisObject.ThisMounth+1), _ThisObject.ThisDay);
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                ThisdayMatchUser _Match = new ThisdayMatchUser().GetTodayUserMatch(_UserID, _date);
                return _Match;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    public class ThisDayMyMatch
    {
        public int ThisDay { get; set; }
        public int ThisMounth { get; set; }
        public int ThisYear{ get; set; }


    }

}
