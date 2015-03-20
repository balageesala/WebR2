using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using IntellidateR1;
namespace IntelliWebR1.API
{
    public class TodayTheyRematchController : ApiController
    {
        public int Post([FromBody]ThisDayMyMatch _ThisObject)
        {
            try
            {
                DateTime _date = new DateTime(_ThisObject.ThisYear, (_ThisObject.ThisMounth + 1), _ThisObject.ThisDay);
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                int _MatchedUserID = new ThisdayMatchUser().GetTodayRematchThem(_UserID, _date);
                return _MatchedUserID;
            }
            catch (Exception)
            {
                return 0;
            }
        }
    }
}
