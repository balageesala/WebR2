$(document).ready(function () {
    CheckIsUserOnline();
    var _api = _SitePath + "api/GetAllSexQuestions";
    $.getDATA(_api, function (_data) {
        if (_data != "") {
            ko.applyBindings(new QuestionListVM(_data), document.getElementById("divMyProfileSexQuestions"));
            setTimeout(function () {
                ShowFirstUnAnswered();
            }, 1000);
        } else {
            $("#divMyProfileSexQuestions").html("You have answred all sex questions.");
        }
    }, function () { });
});