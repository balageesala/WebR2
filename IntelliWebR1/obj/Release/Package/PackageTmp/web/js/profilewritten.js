
$(document).ready(function () {

    var API_OTHERUSER_PROFILE = _SitePath + "api/ProfileWritten";
    var _Object = new Object();
    _Object.OtherUserID = _OtherUserID;
    $.postDATA(API_OTHERUSER_PROFILE, _Object, function (_ret) {
        var _noData = JSON.stringify(_ret).trim();
        if (_noData == "[]" || _ret == "") {
            $("#divprofilewritten").html(" &nbsp;&nbsp; No data find.");
            return;
        }
        ko.applyBindings(new VMDescriptionAnswersList(_ret), document.getElementById("divprofilewritten"));
    });

});





function VMDescriptionAnswers(_ans) {
    var self = this;
    self.AnswerID = ko.observable(_ans.AnswerID);
    self.QuestionId = ko.observable(_ans.QuestionId);
    self.GetQuestion = ko.observable(_ans.GetQuestion);
    self.Answer = ko.observable(_ans.Answer);
    self.UserId = ko.observable(_ans.UserId);
    self.UserRank = ko.observable(_ans.UserRank);
    self.OtherUser = ko.observable(_ans.OtherUser);
    self.CreatedDate = ko.observable(_ans.CreatedDate);
    self.Priority = ko.observable(_ans.Priority);
    self.Status = ko.observable(_ans.Status);
    self.MaxAnswerLength = ko.observable(_ans.MaxAnswerLength);
   
    self.AnswerHtml = ko.computed(function () {
        var _ans = self.Answer();
        if (_ans == "") {
            _ans = "";
        }
        else {
            _ans = replaceAll('\n', '<br />', _ans);
        }

        return _ans;
    }, this);

    self.IsDiscuss = ko.computed(function () {
        var _thispage = window.location.pathname;
        if (_thispage.indexOf("MatchProfile") != -1) {
            return false;
        } else {
            return true;
        }
    }, this);


}

function replaceAll(find, replace, str) {
    return str.replace(new RegExp(find, 'g'), replace);
}

function VMDescriptionAnswersList(_list) {
    var self = this;
    self.AllDescAnswers = ko.observableArray();
    for (var i = 0; i < _list.length; i++) {
        self.AllDescAnswers.push(new VMDescriptionAnswers(_list[i]));
    }

}