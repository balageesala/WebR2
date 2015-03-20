using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class GetUnreadNotificationCountController : ApiController
    {
        public int Get()
        {
            try
            {
               int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
               return new IntellidateR1.Notifications().GetUnViewedNotificationsCount(_UserID);
            }
            catch (Exception)
            {
                return 0;
            }
        }


    }

}
