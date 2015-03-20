

function VMPhilosophy(_question) {
    var self = this;
    self.PhilosophyName = ko.observable(_question.PhilosophyName);
    self.PhilosophyQuestion = ko.observable(_question.PhilosophyQuestion);
    self.PhilosophyType = ko.observable(_question.PhilosophyType);
    self.PhilosophyPreferenceType = ko.observable(_question.PhilosophyPreferenceType);
}

function VMPhilosophyAnswer(_Philosophy) {
    var self = this;
    self.Philosophy_id = ko.observable(_Philosophy.Philosophy_id);
    self.Philosophy = ko.observable(new VMPhilosophy(_Philosophy.Philosophy));
    self.UserID = ko.observable(_Philosophy.UserID);
    self.UserOption = ko.observable(_Philosophy.UserOption);
    self.UserOptionString = ko.observable(_Philosophy.UserOptionString);
    self.UserText = ko.observable(_Philosophy.UserText);
    self.UserOptionDate = ko.observable(_Philosophy.UserOptionDate);
    self.UserOptionDateString = ko.observable(_Philosophy.UserOptionDateString);
    self.UserOptionMultiple = ko.observable(_Philosophy.UserOptionMultiple);
    self.UserOptionMultipleString = ko.observable(_Philosophy.UserOptionMultipleString);
    self.UserPreferenceMultiple = ko.observable(_Philosophy.UserPreferenceMultiple);
    self.UserPreferenceMultipleString = ko.observable(_Philosophy.UserPreferenceMultipleString);
    self.UserNonPreferenceMultipleString = ko.observable(_Philosophy.UserNonPreferenceMultipleString);
    self.UserPreferenceRange = ko.observable(_Philosophy.UserPreferenceRange);
    self.UserPreferenceRangeString = ko.observable(_Philosophy.UserPreferenceRangeString);
    self.UserNonPreferenceRangeString = ko.observable(_Philosophy.UserNonPreferenceRangeString);
    self.HasAllPreferencesSelected = ko.observable(_Philosophy.HasAllPreferencesSelected);
    self.PointsAssigned = ko.observable(_Philosophy.PointsAssigned);
}

function VMPhilosophyAnswerList(_list) {
    var self = this;
    self.AllSnapshot = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllSnapshot.push(new VMPhilosophyAnswer(_list[i]));
    }

}