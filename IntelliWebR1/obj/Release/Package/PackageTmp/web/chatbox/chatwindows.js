function AddNewChatWindow(UserID) {
    AddNewChatWindow(UserID);
}
$(document).ready(function () {
    var _dummy = new Object();
    _dummy.UserID = "0";
    _dummy.Position = 0;
    _dummy.ShowThis = false;
    var _dummyArray = new Array();
    _dummyArray.push(_dummy);

    ko.applyBindings(new VMChatWindowList(_dummyArray), document.getElementById("divChatWindows"));
    ClearDummy();
});

function VMChatWindow(_chatwindow, _userIcon, _conversation) {
    var self = this;
    self.UserID = ko.observable(_chatwindow.UserID);
    self.Position = ko.observable(_chatwindow.Position);
    self.ShowThis = ko.observable(_chatwindow.ShowThis);

    self.CloseImage = ko.computed(function () {
        return _SitePath + "web/chatbox/close.gif";
    });

    self.VoiceCallImage = ko.computed(function () {
        return _SitePath + "web/chatbox/voicecall.jpg";
    });


    self.VideoCallImage = ko.computed(function () {
        return _SitePath + "web/chatbox/video_call.png";
    });

    self.StyleRight = ko.computed(function () {
        //right:4px;
        var _numberOfWindows = self.Position();
        if (_numberOfWindows > 3) {
            _numberOfWindows = 3;
        }

        var _Right = eval(_numberOfWindows * 300);
        _Right = eval(_Right + 10);
        return "right:" + _Right + "px";
    }, this);

    self.UserIcon = ko.observable(_userIcon);

    self.Conversation = ko.observableArray();
    if (_conversation != null) {
        for (var i = 0; i < _conversation.length; i++) {
            self.Conversation.push(new VMConversation(_conversation[i]));
        }
    }
    self.ConversationsAvailable = ko.computed(function () {
        if (self.Conversation().length == 0) {
            return false;
        }
        else {
            return true;
        }
    }, this);


}

function VMConversation(_conv) {
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
    self.HasRecipientSeen = ko.observable(_conv.HasRecipientSeen);
    self.RecipientSeenTime = ko.observable(_conv.RecipientSeenTime);
    self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

    self.MessageTextWithSenderName = ko.computed(function () {
        var _Html = "";
        _Html = "<span style=\"font-weight:bold;\">" + self.Sender().LoginName + ":</span>&nbsp;";

        _Html = _Html + self.MessageText();
        return _Html;
    }, this);
}

function VMChatWindowList(_list) {
    var self = this;
    self.AllWindows = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllWindows.push(new VMChatWindow(_list[i]));
    }

    GetCurrentPosition = function () {
        return self.AllWindows().length;
    };

    CheckUserWindowAlreadyExisting = function (_UserID) {
        var _found = false;
        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].UserID() == _UserID) {
                _found = true;
                break;
            }
        }
        return _found;
    };

    SendMessage = function (_UserID, _chatText) {
        var _chatPostAPI = _SitePath + "api/PostIM";
        var _chatObject = new Object();
        _chatObject.OtherUserID = _UserID;
        _chatObject.MessageText = _chatText;

        $.postDATA(_chatPostAPI, _chatObject, function (_conversation) {
            AddConversation(_conversation, _UserID);
            _conversation.IsUserTheSender = false;
            m_intelliHub.server.sendMessage(_UserID, _conversation);
        });
    };

    AddConversation = function (_conv, _UserID) {
        if (CheckUserWindowAlreadyExisting(_UserID) == false) {
            AddNewChatWindow(_UserID);
            FocusChatWindow(_UserID);

            return;
        }
        var _pos = -1;
        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].UserID() == _UserID) {
                _pos = i;
                break;
            }
        }
        self.AllWindows()[_pos].Conversation.push(new VMConversation(_conv));
        FocusChatWindow(_UserID);
        $(".chatArea").animate({ scrollTop: $('.chatArea')[0].scrollHeight }, 500);
        //$(".chatArea").ekScrollable({ hasScrolled: false });
    };

    FocusChatWindow = function (_UserID) {
        $(".chatText").each(function (i, obj) {
            if ($(obj).data("UserID") == _UserID) {
                $(obj).focus();
                return;
            }
        });
    };

    AddNewChatWindow = function (_UserID) {
       
        if (CheckUserWindowAlreadyExisting(_UserID)) {
            FocusChatWindow(_UserID);
            return;
        }

        var _chatWindowobject = new Object();
        _chatWindowobject.UserID = _UserID;
        _chatWindowobject.Position = GetCurrentPosition();
        _chatWindowobject.ShowThis = true;

        var _displayPicAPI = _SitePath + "api/UserDisplayPic";
        var _userObject = new Object();
        _userObject.UserID = _UserID;
        _userObject.Width = 40;

        $.postDATA(_displayPicAPI, _userObject, function (_displayPic) {
            _displayPic = _SitePath + "web/PhotoView?ImagePath=" + _displayPic;
            //self.AllWindows.push(new VMChatWindow(_chatWindowobject, _SitePath + "web/PhotoView?ImagePath=" + _displayPic));
            var _chatAPI = _SitePath + "api/GetIM";
            var _otherObject = new Object();
            _otherObject.OtherUserID = _UserID;
            $.postDATA(_chatAPI, _otherObject, function (_conversations) {
                self.AllWindows.push(new VMChatWindow(_chatWindowobject, _displayPic, _conversations));
                FocusChatWindow(_UserID);
                //$(".chatArea").ekScrollable({ hasScrolled: false });
                $(".chatArea").animate({ scrollTop: $('.chatArea')[0].scrollHeight }, 500);
                $(".chatText").keydown(function (e) {
                    if (e.keyCode == 13) {
                        var _UserID = $(this).data("UserID");
                        var _chatText = $(this).val().trim();
                        if (_chatText == "") {
                            return false;
                        }
                        $(this).val("")
                        SendMessage(_UserID, _chatText);
                        return false;
                    }
                    if (e.keyCode == 27) {
                        CloseUserWindow($(this).data("UserID"));
                    }
                });
            });
        });
    };

    ClearDummy = function () {
        self.AllWindows.remove(self.AllWindows()[0]);
    };

    CloseWindow = function (_data) {
        var _pos = -1;
        var _windowPos = _data.Position();

        for (var i = 0; i < self.AllWindows().length; i++) {
            if (_data.UserID() == self.AllWindows()[i].UserID()) {
                _pos = i;
            }
        }
        self.AllWindows.remove(self.AllWindows()[_pos]);

        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].Position() > _windowPos) {
                self.AllWindows()[i].Position(self.AllWindows()[i].Position() - 1);
            }
        }

    };

    CloseUserWindow = function (_UserID) {

        var _data;

        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].UserID() == _UserID) {
                _data = self.AllWindows()[i];
                break;
            }
        }

        var _pos = -1;
        var _windowPos = _data.Position();

        for (var i = 0; i < self.AllWindows().length; i++) {
            if (_data.UserID() == self.AllWindows()[i].UserID()) {
                _pos = i;
            }
        }
        self.AllWindows.remove(self.AllWindows()[_pos]);

        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].Position() > _windowPos) {
                self.AllWindows()[i].Position(self.AllWindows()[i].Position() - 1);
            }
        }
    };
}
