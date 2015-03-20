
    $(document).ready(function () {
        $("#btnBack").click(function () {
            window.history.back();
        });
    });

    function VMMessageConversation(_conv) {
        var self = this;
        self.ConversationID = ko.observable(_conv.ConversationID);
        self.SenderID = ko.observable(_conv.SenderID);
        self.Sender = ko.observable(_conv.Sender);
        self.RecipientID = ko.observable(_conv.RecipientID);
        self.Recipient = ko.observable(_conv.Recipient);
        self.MessageText = ko.observable(_conv.MessageText);
        self.HasDelivered = ko.observable(_conv.HasDelivered);
        self.SentTime = ko.observable(_conv.SentTime);
        self.SentTimeUTC = ko.observable(_conv.SentTimeUTC);
        self.SentTimeString = ko.observable(_conv.SentTimeString);

        self.HasRecipientSeen = ko.observable(_conv.HasRecipientSeen);
        self.RecipientSeenTime = ko.observable(_conv.RecipientSeenTime);
        self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

        self.QuestionID = ko.observable(_conv.QuestionID);
        self.PhotoID = ko.observable(_conv.PhotoID);

        self.ShowQuestion = ko.computed(function () {
            if (self.QuestionID() == "" || self.QuestionID() == null) {
                return false;
            }
            else {
                return true;
            }
        }, this);


        self.LoadUrl = ko.computed(function () {
            if (self.ShowQuestion()) {
                var _urlToLoad = _SitePath + "web/inner/questionssinglematch.aspx?uid=" + _OtherUserID + "&pid=" + self.QuestionID();
                return _urlToLoad;
            }
            else {
                return "";
            }
        }, this);

        self.SentTimeStringRel = ko.computed(function () {
            return "(" + self.SentTimeString() + ")";
        }, this);

        self.MessageTextWithSenderName = ko.computed(function () {
            var _Html = "";
            if (self.ShowQuestion()) {
                _Html = "<span style=\"font-weight:bold;font-style:italic;margin-left: 8px;\">" + self.Sender().LoginName + "'s response to the above question: </span>&nbsp;";
            } else {
                _Html = "<span style=\"font-weight:bold;font-style:italic;\">" + self.Sender().LoginName + ":</span>&nbsp;";
            }
            _Html = _Html + self.MessageText();
            return _Html;
        }, this);
    }
function VMMessageConversationList(_list) {
    var self = this;
    self.AllConversations = ko.observableArray();

    for (var i = 0; i < _list.length; i++) {
        self.AllConversations.push(new VMMessageConversation(_list[i]));
    }

    AddNewMessage = function (_obj) {
        self.AllConversations.push(new VMMessageConversation(_obj));
        // $(".timeago").timeago();
        $("#divConversation").animate({ scrollTop: $('#divConversation')[0].scrollHeight }, 500);
    };

    DeleteThisConversation = function (_data) {
        //  alert(_data.ConversationID());
        var _GetConversationAPI = _SitePath + "api/GetConversation/" + _data.ConversationID();
        $.getDATA(_GetConversationAPI, function (_ret) {
            if (_ret) {
                self.AllConversations.remove(_data);
            }
        });
    }



}


var _GetConversationAPI = _SitePath + "api/GetConversation";

$(document).ready(function () {

    var _ConversationPost = new Object();
    _ConversationPost.OtherUserID = _OtherUserID;

    $.postDATA(_GetConversationAPI, _ConversationPost, function (_data) {
        ko.applyBindings(new VMMessageConversationList(_data), document.getElementById("divConversation"));
        setTimeout(function () {
            $(".loadQuestion").each(function (_pos, _obj) {
                var _loadUrl = $(_obj).data("loadurl");
                $(_obj).load(_loadUrl, function () {
                });
            });
        }, 500);
        //  alert($('#divConversation')[0].scrollHeight);
        $("#divConversation").animate({ scrollTop: $('#divConversation')[0].scrollHeight }, 500);
    });


    var ISUSERBLOCKED;

    var _APIISBLOCKED = _SitePath + "api/HasUserBlocked";
    var _BlockedObj = new Object();
    _BlockedObj.BlockedUserID = _OtherUserID;
    $.postDATA(_APIISBLOCKED, _BlockedObj, function (_BlakObject) {
        ISUSERBLOCKED = _BlakObject;
    });


    $("#btnSend").click(function () {
        if ($("#txtReply").val() == "") {
            return;
        }

        if (!ISUSERBLOCKED) {
            alert("this user is blocked");
            return;
        }
        $("#btnSend").attr("disabled", "disabled");
        var _ComposeObj = new Object();
        _ComposeObj.RecipientID = _OtherUserID;
        _ComposeObj.MessageText = $("#txtReply").val();
        _ComposeObj.IsDraft = false;
        var _ComposeAPI = _SitePath + "api/Compose";
        $.postDATA(_ComposeAPI, _ComposeObj, function (_return) {
            $("#btnSend").removeAttr("disabled");
            if (_return != null) {
                $("#txtReply").val("");
                AddNewMessage(_return);
            } else {
                alert("You are restricted to send message until you receive a response.");
            }
            // Close box
        });

    });

});
