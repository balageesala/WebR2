


function VMFilteredConversationSnapShot(_snap) {
    var self = this;
    self.UserID = ko.observable(_snap.UserID);
    self.FilterName = ko.observable(_snap.FilterName);
    self.LastConversation = ko.observable(_snap.LastConversation);
    self.Selected = ko.observable(false);

    self.PassportID = ko.computed(function () {
        return "passport_" + self.UserID();
    }, this);

    self.LoadPassportHtml = ko.computed(function () {
        var _loadUrl = _SitePath + "web/service/LoadControl?c=PASSPORT&ouid=" + self.UserID();
        return _loadUrl;
    }, this);

    self.MessageFilter = ko.computed(function () {
        if (self.FilterName() != "") {
            return self.FilterName();
        } else {
            return "?";
        }
    }, this);

    self.SentTimeFormat = ko.computed(function () {
        var _SentTime = new Date(self.LastConversation().SentTime);
        var _FormatTime = formatTheDate(_SentTime);
        return _FormatTime;
    }, this);

}

function VMFilteredConversationSnapShotList(_snaplist) {
    var self = this;
    self.AllSnapshots = ko.observableArray();
    for (var i = 0; i < _snaplist.length; i++) {
        self.AllSnapshots.push(new VMFilteredConversationSnapShot(_snaplist[i]));
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

    RemoveAndReBindFilterInBox = function (_data) {
        self.AllSnapshots.removeAll();
        for (var i = 0; i < _data.length; i++) {
            self.AllSnapshots.push(new VMFilteredConversationSnapShot(_data[i]));
        }
    }

    RebindDATA = function () {
        var _GetFilteredAPI = _SitePath + "api/FilteredInbox";
        $.getDATA(_GetInboxAPI, function (_data) {
            if (_data == null || _data.length == 0) {
                $("#divFilteredInbox").html("No messages found.");
                $("#divFilteredInbox").addClass("nomessagesdiv");
            } else {
                RemoveAndReBindFilterInBox(_data);
            }
        }, function () { });
    }



    DeleteConversation = function (_data) {

        CheckIsUserOnline();
        var m_SenderId = _data.UserID();
        //alert(m_SenderId);

        var _GetInboxAPI = _SitePath + "api/Inbox/" + m_SenderId;

        $.getDATA(_GetInboxAPI, function (_ret) {
            if (_ret) {
                self.AllSnapshots.remove(_data);
            }
        });
    };



    DeleteSelected = function () {

        //get selected message conversations
        CheckIsUserOnline();
        for (var i = 0; i < self.AllSnapshots().length; i++) {
            if (self.AllSnapshots()[i].Selected()) {
                var m_SenderId = self.AllSnapshots()[i].UserID();
                var _GetInboxAPI = _SitePath + "api/Inbox/" + m_SenderId;
                $.getDATA(_GetInboxAPI, function (_ret) {
                    RebindDATA();
                });
            }
        }
    }



};


var _GetFilteredAPI = _SitePath + "api/FilteredInbox";
$(document).ready(function () {

 

    $.getDATA(_GetFilteredAPI, function (_data) {
        if (_data == null || _data.length == 0) {

            $("#divFilteredInbox").html("No messages found.");
            $("#divFilteredInbox").addClass("nomessagesdiv");
            $(".divloadingimg").hide();
           
        } else {
            ko.applyBindings(new VMFilteredConversationSnapShotList(_data), document.getElementById("divFilteredInbox"));
            setTimeout(function () {
                $(".loadUrl").each(function (_pos, _obj) {
                    var _loadUrl = $(_obj).data("loadurl");
                    $(_obj).load(_loadUrl, function () {
                    });
                });
            }, 500);
            $(".divloadingimg").hide();
            $(".ViewConversation").click(function () {
                window.location.href = "ConversationView?id=" + $(this).data("conv");
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