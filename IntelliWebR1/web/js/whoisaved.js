
function VMProfileSave(_conv) {
    var self = this;
    self._id = ko.observable(_conv._id);
    self._RefID = ko.observable(_conv._RefID);
    self.UserID = ko.observable(_conv.UserID);
    self.ThisUserDetails = ko.observable(_conv.ThisUserDetails);
    self.SaveUserID = ko.observable(_conv.SaveUserID);
    self.SaveUserDetails = ko.observable(_conv.SaveUserDetails);
    self.SavedTime = ko.observable(_conv.SavedTime);
    self.Status = ko.observable(_conv.Status);
    self.SavedAnonymous = ko.observable(_conv.SavedAnonymous);
    self.Matchp = ko.observable(_conv.Matchp);
}

function VMProfileSaveList(_list) {
    var self = this;
    self.AllSavedProfiles = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllViewedProfiles.push(new VMProfileSave(_list[i]));
    }
}