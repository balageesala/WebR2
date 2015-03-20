<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="trashchatview.aspx.cs" Inherits="IntelliWebR1.web.inner.trashchatview" %>
 
<div style="margin-top: 4px; margin-left: 10px; width: 120%; float: left;">
   <div class="BackButton">
            <div id="btnBack">back</div>
        

   </div>

    <div style="float:right;margin-top:-40px;padding-right: 26px;">
            <input type="button" value="DELETE" id="btnDeleteAll" class="deletebtnenable" />
      </div>

     
<div id="divChatTrash" style="margin-left: 20px;height:478px;overflow-y:auto;" data-bind="template: { name: 'template-userconversation', foreach: AllConversations }"></div>
</div>


<script type="text/html" id="template-userconversation">
    <div style="width: 880px;  display: inline-block;">
        <div style="font-family: Arial; font-size: 12px; width: 700px; float: left;  word-break: break-all;" data-bind="html: MessageTextWithSenderName"></div>
        <div style="float: right;width:134px;">
            <div style="float: left;font-size: 12px;" data-bind="text: SentTimeStringRel"></div>
        </div>
    </div>
</script>


<script type="text/javascript">
    function VMMessageConversation(_conv) {
        var self = this;
        self._id = ko.observable(_conv._id);
        self.SenderID = ko.observable(_conv.SenderID);
        self.Sender = ko.observable(_conv.Sender);
        self.RecipientID = ko.observable(_conv.RecipientID);
        self.Recipient = ko.observable(_conv.Recipient);
        self.MessageText = ko.observable(_conv.MessageText);
        self.HasDelivered = ko.observable(_conv.HasDelivered);
        self.SentTime = ko.observable(_conv.SentTime);
        self.SentTimeString = ko.observable(_conv.SentTimeString);

        self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

        self.SentTimeStringRel = ko.computed(function () {
            return "(" + self.SentTimeString() + ")";
        }, this);


        self.MessageTextWithSenderName = ko.computed(function () {
            var _Html = "";
            if (self.IsUserTheSender()) {
                _Html = "<span style=\"font-weight:bold;font-style:italic;\">" + self.Sender().LoginName + ":</span>&nbsp;";
                _Html = _Html + self.MessageText();
            } else {
                _Html = "<span style=\"font-weight:bold;font-style:italic;color:red\">" + self.Sender().LoginName + ":</span>&nbsp;";
                _Html = _Html + self.MessageText();
            }
           
            return _Html;
        }, this);



    }
    function VMMessageConversationList(_list) {
        var self = this;
        self.AllConversations = ko.observableArray();

        for (var i = 0; i < _list.length; i++) {
            self.AllConversations.push(new VMMessageConversation(_list[i]));
        }
    }
</script>
<script type="text/javascript">

    var _GetChatConversationAPI = _SitePath + "api/GetTrashIM";

    $(document).ready(function () {

        var _ConversationPost = new Object();
        _ConversationPost.OtherUserID = _OtherUserID;
        $.postDATA(_GetChatConversationAPI, _ConversationPost, function (_data) {
            ko.applyBindings(new VMMessageConversationList(_data), document.getElementById("divChatTrash"));
            $("#divChatTrash").animate({ scrollTop: $('#divChatTrash')[0].scrollHeight }, 500);
        });

        $("#btnBack").click(function () {
            window.history.back();
        });

        $("#btnDeleteAll").click(function () {
            $("#deleteConfirmBox").dialog("open");
        });

    });

    function YesClicked() {
        CheckIsUserOnline();
        var _ConversationPost = new Object();
        _ConversationPost.OtherUserID = _OtherUserID;
        $.postDATA(_GetChatConversationAPI, _ConversationPost, function (_data) {
            for (var i = 0; i < _data.length; i++) {
                API_TRASHDATA = _SitePath + "api/trash";
                var _ConObj = new Object();
                _ConObj.ConIDs = _data[i]._id;
                $.postDATA(API_TRASHDATA, _ConObj, function (_ret) {
                });
            }
            window.history.back();
        });
        
    }

    function NoClicked() {
        return;
    }


</script>




<script type="text/javascript">

    $(document).ready(function () {

        CheckIsUserOnline();

    });


</script>