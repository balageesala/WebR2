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
    public class GetUnreadMessagesCountController : ApiController
    {

        public int Get()
        {
            try
            {
                if (HttpContext.Current.User.Identity.Name == "")
                {
                    return 0;
                }

                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                var _GetRecivedMessages = new ConversationSnapShot().GetUserReceivedConversationSnapshot(_UserID);
                int _recivedMessagesCount = _GetRecivedMessages.Where(x => x.LastConversation.HasRecipientSeen == false && x.LastConversation.IsDeletedByRecipient == false).ToArray().Count();
                return _recivedMessagesCount;
            }
            catch (Exception)
            {
                return 0;
            }
        }


               
    }
}
