
function VMProfileView(_conv) {
    var self = this;
    self._id = ko.observable(_conv._id);
    self._RefID = ko.observable(_conv._RefID);
    self.UserRefID = ko.observable(_conv.UserRefID);
    self.ViewInvisible = ko.observable(_conv.ViewInvisible);
    self.OtherUserRefID = ko.observable(_conv.OtherUserRefID);
    self.TimeStamp = ko.observable(_conv.TimeStamp);
    self.UserDetails = ko.observable(_conv.UserDetails);
    self.OtherUserDetails = ko.observable(_conv.OtherUserDetails);
    self.Matchp = ko.observable(_conv.Matchp);
}

function VMProfileViewList(_list) {
    var self = this;
    self.AllViewedProfiles = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllViewedProfiles.push(new VMProfileView(_list[i]));
    }
}