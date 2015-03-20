
function VMRecivedConversationSnapShot(_snap) {
    var self = this;
    self.UserID = ko.observable(_snap.UserID);
    self.LastConversation = ko.observable(_snap.LastConversation);
    self.Selected = ko.observable(false);

    self.PassportID = ko.computed(function () {
        return "passport_" + self.UserID();
    }, this);

    self.LoadPassportHtml = ko.computed(function () {
        var _loadUrl = _SitePath + "web/service/LoadControl?c=PASSPORT&ouid=" + self.UserID();
       // var _loadUrl = _SitePath + "web/inner/messagepassport?uid=" + self.UserID();
        return _loadUrl;
    }, this);


    self.SentTimeFormat = ko.computed(function () {
        var _SentTime = new Date(self.LastConversation().SentTime);
        var _FormatTime = formatTheDate(_SentTime);
        return _FormatTime;
    }, this);

}

function VMRecivedConversationSnapShotList(_snaplist) {
    var self = this;
    self.AllRicivedSnapshots = ko.observableArray();
    for (var i = 0; i < _snaplist.length; i++) {
        self.AllRicivedSnapshots.push(new VMRecivedConversationSnapShot(_snaplist[i]));
    }


    IsDeleteAll = ko.computed({
        read: function () {
            var item = ko.utils.arrayFirst(self.AllRicivedSnapshots(), function (item) {
                return item.Selected();
            });
            return item == null;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.AllRicivedSnapshots(), function (person) {
                person.Selected(value);
            });
        }
    });



    SelectAll = ko.computed({
        read: function () {
            var item = ko.utils.arrayFirst(self.AllRicivedSnapshots(), function (item) {
                return !item.Selected();
            });
            return item == null;
        },
        write: function (value) {
            ko.utils.arrayForEach(self.AllRicivedSnapshots(), function (person) {
                person.Selected(value);
            });
        }
    });



    RemoveAndReBindInBox = function (_data) {
        self.AllRicivedSnapshots.removeAll();
        for (var i = 0; i < _data.length; i++) {
            self.AllRicivedSnapshots.push(new VMConversationSnapShot(_data[i]));
        }
    }

    RebindDATA = function () {
        var _GetInboxAPI = _SitePath + "api/Inbox";
        $.getDATA(_GetInboxAPI, function (_data) {
            if (_data.length != 0) {
                RemoveAndReBindInBox(_data);
            } else {
                $("#divRecivedMsgs").html("No messages found.");
                $("#divRecivedMsgs").addClass("nomessagesdiv");
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
                self.AllRicivedSnapshots.remove(_data);
            }
        });
    };

  

    DeleteSelected = function () {

        //get selected message conversations
        CheckIsUserOnline();

        for (var i = 0; i < self.AllRicivedSnapshots().length; i++) {
            if (self.AllRicivedSnapshots()[i].Selected()) {
                var m_SenderId = self.AllRicivedSnapshots()[i].UserID();
                var _GetInboxAPI = _SitePath + "api/Inbox/" + m_SenderId;
                $.getDATA(_GetInboxAPI, function (_ret) {
                    RebindDATA();
                });
            }
        } 
    }


};


function formatDate(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + '' + ampm;
    return date.getMonth() + 1 + "/" + date.getDate() + "/" + date.getYear() + "  " + strTime;
}


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