
function VMPreviousMatch(_Match) {
    var self = this;
    self._id = ko.observable(_Match._id);
    self.UserID = ko.observable(_Match.UserID);
    self.OtherUserID = ko.observable(_Match.OtherUserID);
    self.DateNum = ko.observable(_Match.DateNum);
    self.OtherUser = ko.observable(_Match.OtherUser);
}

function VMPreviousMatchesList(_Matchlist) {
    var self = this;
    self.AllPreviousMatches = ko.observableArray();
    for (var i = 0; i < _Matchlist.length; i++) {
        self.AllPreviousMatches.push(new VMPreviousMatch(_Matchlist[i]));
    }
}