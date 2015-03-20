using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API.Messages
{
    public class DeleteIMConversationController : ApiController
    {
        public bool Post([FromBody]IMCMessage _DelObj)
        {
            int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
            var _GetIMC = new IMConversation().GetIMConversationDateWise(_UserID, _DelObj.OtherUserID, _DelObj.SentDate);
            bool _res = false;
            foreach (var IMChat in _GetIMC)
            {
                _res = new IMConversation().DeleteIMConversation(IMChat._id, _UserID);
            }
            return _res;
        }


    }

    public class IMCMessage
    {
        public int OtherUserID { get; set; }
        public DateTime SentDate { get; set; }

    }



}
