using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using IntellidateR1;
using System.Threading.Tasks;

namespace IntelliWebR1
{
    public class IntelliHub : Hub
    {
        public void Hello()
        {
            Clients.Others.hello();
        }

        static List<OnlineUsers> ConnectedUsers = new List<OnlineUsers>();
        static List<IMConversation> CurrentMessage = new List<IMConversation>();

        public void Connect(int UserID)
        {
            var id = Context.ConnectionId;


            if (ConnectedUsers.Count(x => x.ConnectionID == id) == 0)
            {
                ConnectedUsers.Add(new OnlineUsers { ConnectionID = id, UserID = UserID });

                // send to caller
                Clients.Caller.onConnected(id, UserID, ConnectedUsers, CurrentMessage);

                // send to all except caller client
                Clients.AllExcept(id).onNewUserConnected(id, UserID);

            }

        }

        public void SendPrivateMessage(string toUserId, string message)
        {

            string fromUserId = Context.ConnectionId;

            var toUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionID == toUserId);
            var fromUser = ConnectedUsers.FirstOrDefault(x => x.ConnectionID == fromUserId);

            if (toUser != null && fromUser != null)
            {
                // send to 
                Clients.Client(toUserId).sendPrivateMessage(fromUserId, fromUser.UserID, message);
                int _recipientID=new OnlineUsers().GetUserID(toUserId);
                int _senderID=new OnlineUsers().GetUserID(fromUserId);
                new IMConversation().SendMessage(_senderID, _recipientID, message);
                // send to caller user
                Clients.Caller.sendPrivateMessage(toUserId, fromUser.UserID, message);
            }

        }




        public void userOnline(string UserID)
        {
            Clients.Others.useronline(UserID);
            new OnlineUsers().AddOnlineUser(Convert.ToInt32(UserID), Context.ConnectionId);
        }

        public void userOffline(string UserID)
        {
            Clients.Others.useroffline(UserID);
            new OnlineUsers().RemoveOnlineUser(UserID);
        }

        public void sendMessage(string RecipientID, IMConversation m_IMConversation)
        {
            string _ConnectionID = new OnlineUsers().GetUserConnectionID(Convert.ToInt32(RecipientID));
            if (_ConnectionID != "")
            {
                int _SenderUserID = new OnlineUsers().GetUserID(Context.ConnectionId);
                Clients.Client(_ConnectionID).sendmessage(_SenderUserID, m_IMConversation);
            }
        }

        public override Task OnDisconnected(bool stopCalled = true)
        {
            new OnlineUsers().RemoveOnlineUser(Context.ConnectionId);
            return base.OnDisconnected(stopCalled);
        }

        public void Send(string name, string message)
        {
            // Call the broadcastMessage method to update clients.
            Clients.All.broadcastMessage(name, message);
        }


    }



    public class UserDetail
    {
        public int UserID { get; set; }
        public string ConnectionID { get; set; }
    }

    
   

}