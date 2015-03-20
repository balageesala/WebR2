
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


        self.SentDate = ko.computed(function () {
            return "(" + self.SentTimeString() + ")";
        }, this);


        self.MessageTextWithSenderName = ko.computed(function () {
            var _Html = "";
            if (self.IsUserTheSender()) {
                _Html = "<h4>" + self.Sender().LoginName + ":</h4>&nbsp;";
                _Html = _Html +"<p>"+ self.MessageText()+"</p>";
            } else {
                _Html = "<h5>" + self.Sender().LoginName + ":</h5>&nbsp;";
                _Html = _Html + "<p>" + self.MessageText() + "</p>";
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


    DeleteThisConversation = function (_data) {
        //  alert(_data.ConversationID());
        var _DeleteChatAPI = _SitePath + "api/DeleteChat";
        var _ChatObj = new Object();
        _ChatObj.IM_id = _data._id();
        $.postDATA(_DeleteChatAPI, _ChatObj, function (_ret) {
            if (_ret) {
                self.AllConversations.remove(_data);
            }
        });
    }



}


    var _GetChatConversationAPI = _SitePath + "api/GetIM";

$(document).ready(function () {

    var _ConversationPost = new Object();
    _ConversationPost.OtherUserID = _OtherUserID;
    $.postDATA(_GetChatConversationAPI, _ConversationPost, function (_data) {
        ko.applyBindings(new VMMessageConversationList(_data), document.getElementById("divConversation"));
        $("#divConversation").animate({ scrollTop: $('#divConversation')[0].scrollHeight },0);
    });



    $("#btnBack").click(function () {
        window.location.href = _SitePath + "web/Messages#chat";
    });


    $("#btnDeleteAll").click(function () {
        CheckIsUserOnline();
        var _ConversationPost = new Object();
        _ConversationPost.OtherUserID = _OtherUserID;
        $.postDATA(_GetChatConversationAPI, _ConversationPost, function (_data) {
            for (var i = 0; i < _data.length; i++) {
                var _DeleteChatAPI = _SitePath + "api/DeleteChat";
                var _ChatObj = new Object();
                _ChatObj.IM_id = _data[i]._id;
                $.postDATA(_DeleteChatAPI, _ChatObj, function (_ret) {
                       
                });

            }

            window.history.back();


        });

    });

});


$(document).ready(function () {
    $("#btnBack").click(function () {
        window.history.back();
    });
});