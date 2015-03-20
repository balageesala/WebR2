
function VMIMConversationSnapShot(_snap) {
    var self = this;
    self.UserID = ko.observable(_snap.UserID);
    self.LastConversation = ko.observable(_snap.LastConversation);
    self.Selected = ko.observable(false);

    self.PassportID = ko.computed(function () {
        return "passport_" + self.UserID();
    }, this);

    self.LoadPassportHtml = ko.computed(function () {
        var _loadUrl = _SitePath + "web/service/LoadControl?c=PASSPORT&ouid=" + self.UserID();
        return _loadUrl;
    }, this);


    self.SentTimeFormat = ko.computed(function () {
        var _SentTime = new Date(self.LastConversation().SentTime);
        var _FormatTime = formatTheDate(_SentTime);
        return _FormatTime;
    }, this);

   
}

function VMIMConversationSnapShotList(_snaplist) {
    var self = this;
    self.AllSnapshots = ko.observableArray();
    for (var i = 0; i < _snaplist.length; i++) {
        self.AllSnapshots.push(new VMIMConversationSnapShot(_snaplist[i]));
    }

    IsDeleteAll = ko.computed({
        read: function () {
            var item = ko.utils.arrayFirst(self.AllSnapshots(), function (item) {
                return item.Selected();
            });
            return item == null;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.AllSnapshots(), function (person) {
                person.Selected(value);
            });
        }
    });


    SelectAll = ko.computed({
        read: function () {
            var item = ko.utils.arrayFirst(self.AllSnapshots(), function (item) {
                return !item.Selected();
            });
            return item == null;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.AllSnapshots(), function (person) {
                person.Selected(value);
            });
        }
    });


    RemoveAndReBindChat= function (_data) {
        self.AllSnapshots.removeAll();
        for (var i = 0; i < _data.length; i++) {
            self.AllSnapshots.push(new VMIMConversationSnapShot(_data[i]));
        }
    }

    RebindDATA = function () {
        var _GetChatAPI = _SitePath + "api/GetChat";
        $.getDATA(_GetChatAPI, function (_data) {
            if (_data.length != 0) {
                RemoveAndReBindChat(_data);
                setTimeout(function () {
                    $(".loadUrl").each(function (_pos, _obj) {
                        var _loadUrl = $(_obj).data("loadurl");
                        $(_obj).load(_loadUrl, function () {
                        });
                    });
                }, 500);
                $(".ViewChatConversation").click(function () {
                    window.location.href = "ConversationView?id=" + $(this).data("conv") + "&page=chat";
                });
            } else {
                $("#divChatMsgs").html("No messages found.");
                $("#divChatMsgs").addClass("nomessagesdiv");
            }
        }, function () { });
    }



    DeleteConversation = function (_data) {
        CheckIsUserOnline();
        var _DeleteChatAPI = _SitePath + "api/DeleteIMConversation";
        var _DeleteObj = new Object();
        _DeleteObj.OtherUserID = _data.UserID();
        _DeleteObj.SentDate = _data.LastConversation().SentTime;
       
        $.postDATA(_DeleteChatAPI, _DeleteObj, function (_return) {
            if (_return) {
                self.AllSnapshots.remove(_data);
            }
        });

       
    };



    DeleteSelected = function () {

        //get selected message conversations
        CheckIsUserOnline();

        for (var i = 0; i < self.AllSnapshots().length; i++) {
            if (self.AllSnapshots()[i].Selected()) {
                var _DeleteChatAPI = _SitePath + "api/DeleteIMConversation";
                var _DeleteObj = new Object();
                _DeleteObj.OtherUserID = self.AllSnapshots()[i].UserID();
                _DeleteObj.SentDate = self.AllSnapshots()[i].LastConversation().SentTime;
                $.postDATA(_DeleteChatAPI, _DeleteObj, function (_return) {
                    if (_return) {
                        RebindDATA();
                    }
                });
            }
        }
    }


};


var _GetChatAPI = _SitePath + "api/GetChat";
$(document).ready(function () {
    $.getDATA(_GetChatAPI, function (_data) {
        if (_data == null || _data.length == 0) {
            $("#divChatMsgs").html("No messages found.");
            $("#divChatMsgs").addClass("nomessagesdiv");
            $(".divloadingimg").hide();
        } else {
            // alert(JSON.stringify(_data));
            ko.applyBindings(new VMIMConversationSnapShotList(_data), document.getElementById("divChatMsgs"));
            setTimeout(function () {
                $(".loadUrl").each(function (_pos, _obj) {
                    var _loadUrl = $(_obj).data("loadurl");
                    $(_obj).load(_loadUrl, function () {
                    });
                });
            }, 500);
            $(".divloadingimg").hide();
            $(".ViewChatConversation").click(function () {
                window.location.href = "ConversationView?id=" + $(this).data("conv") + "&page=chat";
            });
        }
    }, function () { });
});


function formatTheDate(d) {
    var month = d.getMonth();
    var day = d.getDate();
    var year = d.getFullYear();

    year = year.toString().substr(2, 2);

    month = month + 1;

    month = month + "";

    if (month.length == 1) {
        month = "0" + month;
    }

    day = day + "";

    if (day.length == 1) {
        day = "0" + day;
    }

    var hours = d.getHours();
    var minutes = d.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var _hoursString;
    if (hours < 10) {
        _hoursString = "0" + hours;
    } else {
        _hoursString = hours;
    }
    var strTime = _hoursString + ':' + minutes + '' + ampm;

    return month + "/" + day + "/" + year + " " + strTime;
}