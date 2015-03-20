using IntellidateR1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;

namespace IntelliWebR1.API
{
    public class TrashController : ApiController
    {

        // GET api/<controller>
        [HttpGet]
        public IEnumerable<TrashedConversationSnapShot> Get()
        {
            try
            {
                int _UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                List<TrashedConversationSnapShot> _RecConversation = new TrashedConversationSnapShot().GetTrashedConversationSnapShot(_UserID);
                return _RecConversation;
            }
            catch (Exception)
            {
                return null;
            }
        }

        // GET api/<controller>/5 deleting trash
        public bool Post([FromBody]ConversationIDs ConIDObj)
        {
            try
            {
                int m_UserID = Convert.ToInt32(HttpContext.Current.User.Identity.Name);
                bool m_res = false;
                foreach (string Con_id in ConIDObj.ConIDs)
                { 
                   if(Regex.IsMatch(Con_id, @"^\d+$"))
                    {
                        int ConversationID=Convert.ToInt32(Con_id);
                         m_res = new Conversation().TrashConversation(ConversationID, m_UserID);
                    }
                   else
                   {
                       //trash chat conversation
                       m_res = new IMConversation().TrashIMConversation(Con_id, m_UserID);
                   }
                }
                return m_res;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }

    public class ConversationIDs
    {
        public string[] ConIDs { get; set; }

    }



}
