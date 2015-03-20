
function VMChatView(_in) {
    var self = this;
    self.SentDate = ko.observable(_in.SentDate);
    self.ThisView = ko.observable(new VMChildView(_in.ThisView));
    self.SentDateFormate = ko.computed(function () {
        return formatTheDate(self.SentDate());
    });
}


function VMChatList(_list) {
    var self = this;
    self.AllConversations = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllConversations.push(new VMChatView(_list[i]));
    }
}

function VMChildView(_lst) {
    var self = this;
    self.AllChilds = ko.observableArray();
    for (var i = 0; i < _lst.length; i++) {
        self.AllChilds.push(new ChatConversationVM(_lst[i]));
    }
}

function ChatConversationVM(_conv) {
    var self = this;
    self._id = ko.observable(_conv._id);
    self.SenderID = ko.observable(_conv.SenderID);
    self.Sender = ko.observable(_conv.Sender);
    self.RecipientID = ko.observable(_conv.RecipientID);
    self.Recipient = ko.observable(_conv.Recipient);
    self.MessageText = ko.observable(_conv.MessageText);
    self.HasDelivered = ko.observable(_conv.HasDelivered);
    self.SentTime = ko.observable(_conv.SentTime);
    self.IsUserTheSender = ko.observable(_conv.IsUserTheSender);

    self.SentTimeFormate = ko.computed(function () {
        return formatTheTime(self.SentTime());
    });

    self.MessageTextWithSenderName = ko.computed(function () {
        var _Html = "";
        if (self.IsUserTheSender()) {
            _Html = "<h4>" + self.Sender().LoginName + ":</h4>";
            _Html = _Html +"<p>"+ self.MessageText()+"</p>";
        } else {
            _Html = "<h5>" + self.Sender().LoginName + ":</h5>";
            _Html = _Html + "<p>" + self.MessageText() + "</p>";
        }
        return _Html;
    });




}



function formatTheDate(thedate) {

    thedate = new Date(thedate);
    var month = thedate.getMonth();
    var day = thedate.getDate();
    var year = thedate.getFullYear();

    month = month + 1;

    month = month + "";

    if (month.length == 1) {
        month = "0" + month;
    }

    day = day + "";

    if (day.length == 1) {
        day = "0" + day;
    }
    return month + "/" + day + "/" + year ;
}


function formatTheTime(frmdate) {
    frmdate = new Date(frmdate);
    var hours = frmdate.getHours();
    var minutes = frmdate.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12;
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var _hoursString;
    if (hours < 10) {
        _hoursString = "0" + hours;
    } else {
        _hoursString = hours;
    }
    var strTime = _hoursString + ':' + minutes + '' + ampm;

    return  strTime;
}