
function VMCriteria(_criteria) {
    var self = this;
    self.CriteriaName = ko.observable(_criteria.CriteriaName);
    self.UserPreferences = ko.observable(_criteria.UserPreferences);
    self.OtherUserValue = ko.observable(_criteria.OtherUserValue);
    self.PointsAssigned = ko.observable(_criteria.PointsAssigned);
    self.PointsAwarded = ko.observable(_criteria.PointsAwarded);
    self.IsMatch = ko.observable(_criteria.IsMatch);
    self.HasAllPreferencesSelected = ko.observable(_criteria.HasAllPreferencesSelected);
    self.ShowMatch = ko.observable(_criteria.ShowMatch);
    self.CriteriaType = ko.observable(_criteria.CriteriaType);
    self.HideCriteriaInUserMatch = ko.observable(_criteria.HideCriteriaInUserMatch);
    self.HideCriteriaInOtherUserMatch = ko.observable(_criteria.HideCriteriaInOtherUserMatch);
    self.HideOtherUserValue = ko.observable(_criteria.HideOtherUserValue);
    self.MatchSuccessText = ko.observable(_criteria.MatchSuccessText);
    self.MatchFailText = ko.observable(_criteria.MatchFailText);
}


function VMCriteriaList(_list) {
    var self = this;
    self.AllSnapshot = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllSnapshot.push(new VMCriteria(_list[i]));
    }
}


function VMOtherUserCriteria(_uc) {
    var self = this;
    self.CriteriaName = ko.observable(_uc.CriteriaName);
    self.UserPreferences = ko.observable(_uc.UserPreferences);
    self.OtherUserValue = ko.observable(_uc.OtherUserValue);
    self.PointsAwarded = ko.observable(_uc.PointsAwarded);
    self.IsMatch = ko.observable(_uc.IsMatch);
    self.HasAllPreferencesSelected = ko.observable(_uc.HasAllPreferencesSelected);
    self.ShowMatch = ko.observable(_uc.ShowMatch);
    self.HideCriteriaInUserMatch = ko.observable(_uc.HideCriteriaInUserMatch);
    self.HideCriteriaInOtherUserMatch = ko.observable(_uc.HideCriteriaInOtherUserMatch);
    self.HideOtherUserValue = ko.observable(_uc.HideOtherUserValue);
    self.Criteria_id = ko.observable(_uc.Criteria_id);
}


function VMOtherUserCriteriaList(_UClist) {
    var self = this;
    self.AllOtherSnapshot = ko.observableArray();
    for (var i = 0; i < _UClist.length; i++) {
        self.AllOtherSnapshot.push(new VMOtherUserCriteria(_UClist[i]));
    }
}
