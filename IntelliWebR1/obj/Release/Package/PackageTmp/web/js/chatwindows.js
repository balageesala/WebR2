
    function VMChatWindow(_chatwindow, _userName, _conversation) {
        var self = this;
        self.UserID = ko.observable(_chatwindow.UserID);
        self.Position = ko.observable(_chatwindow.Position);
        self.ShowThis = ko.observable(_chatwindow.ShowThis);

        self.CloseImage = ko.computed(function () {
            return _SitePath + "web/images/close_white.png";
        });

        self.VoiceCallImage = ko.computed(function () {
            return _SitePath + "web/chatbox/voicecall.jpg";
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

        self.UserName = ko.observable(_userName);
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
    self.SentTimeString = ko.observable(_conv.SentTimeString);
    self.HasRecipientSeen = ko.observable(_conv.HasRecipientSeen);
    self.RecipientSeenTime = ko.observable(_conv.RecipientSeenTime);
    self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

    self.MessageTextWithSenderName = ko.computed(function () {
        var _Html = "";
        _Html = "<span style=\"font-weight:bold;\">" + self.Sender().LoginName + ":</span>&nbsp;";

        _Html = _Html + self.MessageText();
        return _Html;
    }, this);


    self.MessageTextWithPic = ko.computed(function () {
        var _Html = "";

        if (self.SenderID() != _ThisUserID) {
            var _PhotoUrl = _SitePath + "web/service/UserPhoto?uid=" + self.SenderID();

            _Html = "<div class=\"divcircileleft\"><img class=\"divcircile\" src=" + _PhotoUrl + " /></div>";

            _Html = _Html + "<div class=\"divchattext\">" + self.MessageText() + "</div>";
            _Html = _Html + "<div class=\"divsentTimeleft\">" + self.SentTimeString() + "</div>";
        } else {
            var _PhotoUrl = _SitePath + "web/service/UserPhoto?uid=" + self.SenderID();

            _Html = "<div class=\"divcircile\"><img class=\"divcircile\" src=" + _PhotoUrl + " /></div>";

            _Html = _Html + "<div class=\"divchattext\">" + self.MessageText() + "</div>";
            _Html = _Html + "<div class=\"divsentTime\">" + self.SentTimeString() + "</div>";
        }

           
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

    SendMessage = function (_userID, _chatText) {
        CheckIsUserOnline();
        var _chatPostAPI = _SitePath + "api/PostIM";
        var _chatObject = new Object();
        _chatObject.OtherUserID = _userID;
        _chatObject.MessageText = _chatText;

        $.postDATA(_chatPostAPI, _chatObject, function (_conversation) {
            if (_conversation.SenderID != 0) {
                AddConversation(_conversation, _userID);
                _conversation.IsUserTheSender = false;
                m_intelliHub.server.sendMessage(_userID, _conversation);
            } else {
                // $("#divChatWindows").html(_conversation.MessageText);
                alert(_conversation.MessageText);
            }
               
        });
    };

    AddConversation = function (_conv, _userID) {
        if (CheckUserWindowAlreadyExisting(_userID) == false) {
            AddNewChatWindow(_userID);
            FocusChatWindow(_userID);

            return;
        }
        var _pos = -1;
        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].UserID() == _userID) {
                _pos = i;
                break;
            }
        }
        self.AllWindows()[_pos].Conversation.push(new VMConversation(_conv));
        FocusChatWindow(_userID);
        for (var i = 0; i < $('.chatArea').length; i++) {
            $(".chatArea").animate({ scrollTop: $('.chatArea')[i].scrollHeight }, 500);
        }
          
        //$(".chatArea").ekScrollable({ hasScrolled: false });
    };

    FocusChatWindow = function (_userID) {
        $(".chatText").each(function (i, obj) {
            if ($(obj).data("userid") == _userID) {
                $(obj).focus();
                return;
            }
        });
    };

    AddNewChatWindow = function (_userID) {
          
       

        var API_Online = _SitePath + "api/IsOtherUserOnline";
        var m_OtherObj= new Object();
        m_OtherObj.OtherUserID = _userID;

        $.postDATA(API_Online, m_OtherObj, function (_ret) {
            // alert(_ret);
            if (_ret) {
                var API_AbleToChat = _SitePath + "api/IsUserAbleToChat";
                $.postDATA(API_AbleToChat, m_OtherObj, function (_ret) {
                    // alert(_ret);
                    if (_ret) {
                        if (CheckUserWindowAlreadyExisting(_userID)) {
                            FocusChatWindow(_userID);
                            return;
                        }

                        var _chatWindowobject = new Object();
                        _chatWindowobject.UserID = _userID;
                        _chatWindowobject.Position = GetCurrentPosition();
                        _chatWindowobject.ShowThis = true;

                        var _UserNameAPI = _SitePath + "api/GetUserDetails";
                        var _userObject = new Object();
                        _userObject.OtherUserID = _userID;


                        $.postDATA(_UserNameAPI, _userObject, function (_User) {
                            var _UserName = _User.LoginName;
                            //self.AllWindows.push(new VMChatWindow(_chatWindowobject, _SitePath + "web/PhotoView?ImagePath=" + _displayPic));
                            var _chatAPI = _SitePath + "api/GetChatWindow";
                            var _otherObject = new Object();
                            _otherObject.OtherUserID = _userID;
                            $.postDATA(_chatAPI, _otherObject, function (_conversations) {
                                self.AllWindows.push(new VMChatWindow(_chatWindowobject, _UserName, _conversations));
                                FocusChatWindow(_userID);
                                //$(".chatArea").ekScrollable({ hasScrolled: false });
                                $(".chatArea").animate({ scrollTop: $('.chatArea')[0].scrollHeight }, 500);
                                $(".chatText").keydown(function (e) {
                                    if (e.keyCode == 13) {
                                        var _chatText = $(this).val().trim();
                                        if (_chatText != "") {
                                            var _userID = $(this).data("userid");
                                            $(this).val("")
                                            SendMessage(_userID, _chatText);
                                            return false;
                                        }
                                    }
                                    if (e.keyCode == 27) {
                                        CloseUserWindow($(this).data("userid"));
                                    }
                                });
                            });
                        });

                    } else {

                        // alert("You can't able to chat with out communication.");
                    }


                });
            } else {
                //  alert("This user is offline so you can't able to chat.");

            }
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

    CloseUserWindow = function (_userID) {

        var _data;

        for (var i = 0; i < self.AllWindows().length; i++) {
            if (self.AllWindows()[i].UserID() == _userID) {
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

