using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class DeleteNotificationController : ApiController
    {

        public bool Post([FromBody]NotiClass _NotiObj)
        {
            try
            {
                IntellidateR1.Notifications _OneNotifiCation = new IntellidateR1.Notifications().GetNotification(_NotiObj.NotificationID);

                IntellidateR1.Notifications[] _GetArry = new IntellidateR1.Notifications().GetNotificationBasedonType(_OneNotifiCation.UserID, _OneNotifiCation.OtherUserID, _OneNotifiCation.NotificationType);

                bool Result = false;
                foreach (var _Single in _GetArry)
                {
                    Result = new IntellidateR1.Notifications().DeleteUserNotification(_Single.NotificationID);
                }

                return Result;

            }
            catch (Exception)
            {
                return false;
            }
        }

    }

    public class NotiClass
    {
        public int NotificationID { get; set; }

    }

}
